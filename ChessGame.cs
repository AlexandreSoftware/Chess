using System;
using System.Threading;
using BoardNS;
using BoardNS.Pieces;
using System.Collections.Generic;
namespace Chess {
    partial class ChessGame{
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
            if(checkColor!=null)
            System.Console.WriteLine("CHECK from color: "+checkColor);
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
            if(isincheck(currentPlayer)){
                undoMovement(p,dest.ToPosition(),init.ToPosition());
                throw new BoardException("You can't put yourself in check");
            }
            else if(isincheck(adversary(currentPlayer))){
                checkColor=currentPlayer;
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

