using BoardNS;
using BoardNS.Pieces;
using System;
using System.Threading;
using System.Collections.Generic;
namespace Chess{
    partial class ChessGame{
            
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
            Screen.printChessAction(bor,()=>Thread.Sleep(10));
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
        /// <summary>
        /// Checks if a unit is ready for promotion,
        /// when the unit is promoted it promotes using the promotion method
        /// </summary>
        /// <br />
        /// <seealso cref="promotion"/>
        private void checkPromotion(){
            for (int i = 0; i < bor.columns; i++)
            {
                Piece white=bor.piece(0,i);
                if(white!=null&&white is Pawn&& white.color==Color.White){
                    promotion(new Position(0,i));
                    return;
                }
                Piece black=bor.piece(7,i);
                if(black!=null&&black is Pawn&& black.color==Color.Black){
                    promotion(new Position(0,i));
                    return;
                }
            }
        }
        /// <summary>
        /// Gets the promotion input
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool getPromotionInput(out int i){
            i=5;
            Console.Clear();
            Screen.printChessAction(bor,()=>Thread.Sleep(10));
            Console.WriteLine("PROMOTION: choose a Piece:\n"+
                "1-Tower\n2-Bishop\n3-Horse\n4-Queen");
            char a =Console.ReadKey().KeyChar;
            return Char.IsDigit(a)&&int.TryParse(a.ToString(),out i)&&i<5;
        }
        /// <summary>
        /// Calls getPromotionIput to make the user choose a promotion target
        /// <Br />
        /// Then promotes the unit based on the input, with the method checkPromotion
        /// </summary>
        /// <para />
        /// <seealso cref="getPromotionInput"/>
        /// <br />
        /// <para />    
        /// <seealso cref="checkPromotion"/>
        /// <param name="dest">The Position of the piece about to be promoted</param>
        private void promotion(Position dest){
            bool val=true;
            while(!getPromotionInput(out int i)){
                switch (i){
                    case 1:
                        val=promoteUnit(new Tower(bor,bor.piece(dest).color),dest);
                    break;
                    case 2:
                        val=promoteUnit(new Bishop(bor,bor.piece(dest).color),dest);
                    break;
                    case 3:
                        val=promoteUnit(new Horse(bor,bor.piece(dest).color),dest);
                    break;
                    case 4:
                        val=promoteUnit(new Queen(bor,bor.piece(dest).color),dest);
                    break;
                    default:
                        Console.WriteLine("ERROR: Invalid Input");
                    break;                     
                }
            }
        }
        /// <summary>
        /// promote a unit, removing the old piece from the board, and pieces in the play
        /// </summary>
        /// <param name="p">the piece to be promoted</param>
        /// <param name="pos">the position of the promoted unit</param>
        /// <returns></returns>
        private bool promoteUnit(Piece p,Position pos){
            Piece temp =bor.withdrawPiece(pos);
            pieces.Remove(temp);     
            addpiece(p,pos);
            while(temp.mvmtAmount!=bor.piece(pos).mvmtAmount){
                bor.piece(pos).increasemvmtAmount();
            }
            return false;
        }
    }
}