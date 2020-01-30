using System;
using BoardNS;
using BoardNS.Pieces;
using System.Collections.Generic;
namespace Chess {
    class ChessGame{
        bool gameIsFinished = false;
        HashSet<Piece> pieces;
        List<Piece> capturedWhites;
        List<Piece> capturedBlacks;
        Board bor;
        Color currentPlayer;
        int turn;
        bool[,] possiblemvmnts;
        public Color? checkColor;
        public ChessGame(){
            this.gameIsFinished = false;
            pieces= new HashSet<Piece>();
            this.capturedWhites = new List<Piece>();
            this.capturedBlacks = new List<Piece>();
            this.bor = new Board(8, 8);
            this.currentPlayer=Color.White;
            this.turn=0;
            this.checkColor=null;
            this.possiblemvmnts=null;
        }
        private void mountScreen(){
            Console.Clear();
            Screen.printChess(bor);
            if(checkColor!=null){
                System.Console.WriteLine("CHECK from color: "+checkColor);
            }
            Console.Write("White Pieces:[");
            foreach (Piece item in capturedWhites) {
                Console.Write(item+" ");
            }
            ConsoleColor consoleColor=Console.ForegroundColor;
            Console.Write("]\n");
            Console.ForegroundColor=ConsoleColor.Yellow;
            Console.Write("Black Pieces:[");
            foreach (Piece item in capturedBlacks) {
                Console.Write(item+" ");
            }
            Console.Write("]");
            Console.ForegroundColor=consoleColor;
            Console.WriteLine("\nCurrent Player: {0}",currentPlayer);
            System.Console.WriteLine("Turn:{0}",turn);
        }  
        public void GameLoop() {
            Board(bor);
            while (!gameIsFinished) {
                mountScreen();
                try{
                    ChessPosition init =getInit();
                    ChessPosition dest= getDest(init);
                    executePlay(init,dest);
                } 
                catch(BoardException e){
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
        }
        public ChessPosition getDest(ChessPosition init){
            if (bor.validPosition(init.ToPosition()) && bor.pieceExists(init.ToPosition())) {
                if(bor.piece(init.ToPosition()).color==currentPlayer){
                    Piece p1 = bor.piece(init.ToPosition());
                    bool[,] possiblemvmnts=p1.possibleMovements();
                    Screen.printChessFunc(bor,(i,j)=>(possiblemvmnts[i,j]));
                    Console.Write("Destiny: ");
                    return Screen.readChessPosition();
                            
                }
                else{
                    throw new BoardException("Invalid Play: it's not your turn");
                }                    
            }
            else{
                throw new BoardException("Invalid Output:Try again");
                                                
            }
        }
        private void executePlay(ChessPosition init,ChessPosition dest){
            Piece Piece = bor.piece(init.ToPosition());
            bool[,] possiblemvmnts= Piece.possibleMovements();
            Piece p=executeMovement(possiblemvmnts,init.ToPosition(),dest.ToPosition());
            checkPromotion();
            Piece.increasemvmtAmount();
            if(isincheck(adversary(currentPlayer))){
                undoMovement(p,dest.ToPosition(),init.ToPosition());
                throw new BoardException("You can't put yourself in check");
            }
            else if(isincheck(currentPlayer)){
                checkColor=adversary(currentPlayer);
            }
            else{
                checkColor=null;
            }
            if(checkColor!=null){   
                gameIsFinished=testcheckmate((Color)checkColor);
                if(gameIsFinished){
                    throw new BoardException("Game was finished, the winner  was: "+adversary((Color)checkColor));
                }
            }
            if(bor.potentialEmPassant!=null){
                bor.emPassant=bor.potentialEmPassant;
            }
            else{
                bor.emPassant=null;
                bor.emPassant=null;
            }
            turn++;
            passTurn();
        }

        private void undoMovement(Piece capturedPiece,Position dest,Position init){
            if(capturedPiece!=null){
                bor.movepiece(dest,init);
                bor.putPiece(capturedPiece,dest);
                pieces.Add(capturedPiece);
                if(capturedPiece.color==Color.White){
                    capturedWhites.Remove(capturedPiece);
                }
                else{
                    capturedBlacks.Remove(capturedPiece);
                }
                bor.piece(init).decreasemvmtAmount();
            }
            else{
                bor.movepiece(dest,init);
            }
        }
        private void addCapturedPiece(Piece p2){
            if (p2!=null) {
                pieces.Remove(p2);
                if (p2.color == Color.White) {
                    capturedWhites.Add(p2);
                }
                else {
                    capturedBlacks.Add(p2);
                }
            }
        }
        private Piece executeMovement(bool[,] possiblemvmnts,Position init,Position dest){
            if(bor.emPassant!=null&&bor.piece(bor.emPassant)!=null){
                Position squareBefore=bor.squareBefore(bor.emPassant);
                if(possiblemvmnts[squareBefore.line,squareBefore.column]&&dest.line==squareBefore.line&&dest.column==squareBefore.column){
                    bor.movepiece(init,dest);
                    Piece p2=bor.withdrawPiece(bor.emPassant);
                    addCapturedPiece(p2);
                    return p2;
                }
            }
            if(possiblemvmnts[dest.line,dest.column]==true&&bor.piece(dest)!=null&&bor.piece(init).color==bor.piece(dest).color){
                Piece p2 = bor.movepiece(init, dest);
                bor.putPiece(p2,init);
                p2.increasemvmtAmount();
                return null;                
            }
            else if(possiblemvmnts[dest.line,dest.column]==true){
                Piece p2 = bor.movepiece(init, dest);
                addCapturedPiece(p2);
                return p2;
            }
            else {
                throw new BoardException("Impossible Movement: invalid destiny, press any key to continue");                
            }
        }
        private ChessPosition getInit(){
            Console.Write("Origin: ");
            return Screen.readChessPosition();
        }
    
        private void Board(Board bor) {
            for (char i = 'a'; i < 'h' + 1; i++) {
                addpiece(new Pawn(bor, Color.White), new ChessPosition(i, 2).ToPosition());
                addpiece(new Pawn(bor, Color.Black), new ChessPosition(i, 7).ToPosition());
            }
            //BlackS
            addpiece(new Tower(bor, Color.Black), new ChessPosition('a', 8).ToPosition());  
            addpiece(new Horse(bor, Color.Black), new ChessPosition('b', 8).ToPosition());
            addpiece(new Bishop(bor, Color.Black), new ChessPosition('c', 8).ToPosition());
            addpiece(new Queen(bor, Color.Black), new ChessPosition('d', 8).ToPosition());
            addpiece(new King(bor, Color.Black), new ChessPosition('e', 8).ToPosition());
            addpiece(new Bishop(bor, Color.Black), new ChessPosition('f', 8).ToPosition());
            addpiece(new Horse(bor, Color.Black), new ChessPosition('g', 8).ToPosition());
            addpiece(new Tower(bor, Color.Black), new ChessPosition('h', 8).ToPosition());
            //WhiteS                                                                      
            addpiece(new Tower(bor, Color.White), new ChessPosition('a', 1).ToPosition());
            addpiece(new Horse(bor, Color.White), new ChessPosition('b', 1).ToPosition());
            addpiece(new Bishop(bor, Color.White), new ChessPosition('c', 1).ToPosition());
            addpiece(new King(bor, Color.White), new ChessPosition('d', 1).ToPosition());
            addpiece(new Queen(bor, Color.White), new ChessPosition('e', 1).ToPosition());
            addpiece(new Bishop(bor, Color.White), new ChessPosition('f', 1).ToPosition());
            addpiece(new Horse(bor, Color.White), new ChessPosition('g', 1).ToPosition());
            addpiece(new Tower(bor, Color.White), new ChessPosition('h', 1).ToPosition());
            Screen.printChessDelay(bor);
        }
        private HashSet<Piece> piecesingame(Color Color){
            HashSet<Piece> piecesingame=new HashSet<Piece>();
            foreach(Piece x in pieces){
                if(x.color==Color){
                    piecesingame.Add(x);
                } 
            }
            return piecesingame;
        }
        public bool isincheck(Color Color){
            Piece R=King(Color);
            Position realEmPassant=null;
            Position realPotencialEmpassant=null;
            if(bor.emPassant!=null){
                realEmPassant= new Position(bor.emPassant.line,bor.emPassant.column);
            }
            if(bor.potentialEmPassant!=null){
                realPotencialEmpassant=new Position(bor.potentialEmPassant.line,bor.potentialEmPassant.column);
            }
            foreach(Piece piece in piecesingame(adversary(Color))){                
                bool[,] mat=piece.possibleMovements();
                bor.emPassant=realEmPassant;
                bor.potentialEmPassant=realPotencialEmpassant;
                if(mat[R.position.line,R.position.column]&&R.color!=piece.color){
                    return true;
                }
            }
            return false;
        }
        public bool testcheckmate(Color? Color){
            if(isincheck((Color)Color)){return false;}
            foreach (Piece item in piecesingame(adversary((Color)Color))){
                if(item.position!=null){
                    bool[,] mat = item.possibleMovements();
                    for(int i=0;i<bor.lines;i++){
                        for (int j = 0; j < bor.columns; j++)
                        {
                            if(mat[i,j]){
                                Position init=new Position(item.position.line,item.position.column);
                                Piece capturedPiece = executeMovement(mat,item.position,new Position(i,j));
                                bool check= isincheck((Color)checkColor);
                                undoMovement(capturedPiece,item.position,init);
                                if(!check){
                                    return false;
                                }
                                
                            }
                        }
                    }
                }
            }
            return true;
        }
        private void checkPromotion(){
            for (int i = 0; i < bor.columns; i++)
            {
                Piece white=bor.piece(0,i);
                if(white!=null&&white is Pawn&& white.color==Color.White){
                    promocao(new Position(0,i));
                }
                Piece black=bor.piece(7,i);
                if(black!=null&&black is Pawn&& black.color==Color.Black){
                    promocao(new Position(0,i));
                }
            }
        }
        private void promocao(Position dest){
            bool val=true;
            while(val){
                Console.Clear();
                Screen.printChessDelay(bor);
                Console.WriteLine("PROMOTION: choose a Piece:");
                Console.WriteLine("1-Tower\n2-Bishop\n3-Horse\n4-Queen");
                char a =Console.ReadKey().KeyChar;
                if(Char.IsDigit(a)){
                    Piece temp;
                    Position pos = new Position(dest.line,dest.column);
                    if(int.TryParse(a.ToString(),out int i)){
                            switch (i)
                            {
                                case 1:
                                    temp =bor.withdrawPiece(dest);
                                    pieces.Remove(temp);                                
                                    addpiece(new Tower(bor,temp.color),pos);
                                    while(temp.mvmtAmount!=bor.piece(dest).mvmtAmount){
                                        bor.piece(dest).increasemvmtAmount();
                                    }
                                    val=false;
                                break;
                                case 2:
                                    temp =bor.withdrawPiece(dest);
                                    pieces.Remove(temp);                                
                                    addpiece(new Bishop(bor,temp.color),pos);
                                    while(temp.mvmtAmount!=bor.piece(dest).mvmtAmount){
                                        bor.piece(dest).increasemvmtAmount();
                                    }
                                    val=false;
                                break;
                                case 3:
                                    temp =bor.withdrawPiece(dest);
                                    pieces.Remove(temp);                                
                                    addpiece(new Horse(bor,temp.color),pos);
                                    while(temp.mvmtAmount!=bor.piece(dest).mvmtAmount){
                                        bor.piece(dest).increasemvmtAmount();
                                    }
                                    val=false;
                                break;
                                
                                case 4:
                                    temp =bor.withdrawPiece(dest);
                                    pieces.Remove(temp);                                
                                    addpiece(new Queen(bor,temp.color),pos);
                                    while(temp.mvmtAmount!=bor.piece(dest).mvmtAmount){
                                        bor.piece(dest).increasemvmtAmount();
                                    }
                                    val=false;
                                break;
                                
                                default:
                                    Console.WriteLine("ERROR: Invalid Input");
                                break;                     
                                }
                            }
                    }
                }
            }
        private void addpiece(Piece piece, Position pos){
            bor.putPiece(piece,pos);
            pieces.Add(piece);
        }
        private void passTurn()=>currentPlayer=currentPlayer==Color.White?Color.Black:Color.White;
        private King King(Color color){
            foreach (Piece piece in pieces)
            {
                if(piece is King&&piece.color==color){
                    return (King)piece;
                }
            }
            throw new BoardException("There's no king on the board, this really shoudn't happen");
        }
        private Color adversary(Color color)=>color==Color.White? Color.Black:Color.White;
    } 
}

