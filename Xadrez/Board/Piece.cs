using System.Collections.Generic;

namespace BoardNS
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int mvmtAmount { get; protected set; }
        public Board bor { get; protected set; }
        protected bool canMove(Position pos){
            Piece p = bor.Piece(pos);
            return p==null||p.color!=color;
        }
         public Piece(color color){
            this.Position =null;
            this.bor = null;
            this.color = color;
            this.mvmtAmount = 0;

        }
        public Piece(Board bor,color color){
            this.Position = null;
            this.bor = bor;
            this.color = color;
            this.mvmtAmount = 0;

        }
        public abstract bool[,] possibleMovements();
        public void increasermvmtAmount(){
            mvmtAmount++;
        }        
        public void decreasemvmtAmount(){
            mvmtAmount--;
        }        
        protected bool isEnemyPiece(Position pos){
            Piece p2= bor.Piece(pos);
            if(p2!=null){
                return p2.color!=color;
            }
            return false;
        }

    }
}

