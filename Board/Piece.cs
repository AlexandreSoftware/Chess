namespace BoardNS
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int mvmtAmount { get; protected set; }
        public Board bor { get; protected set; }
        protected bool canMove(Position pos){
            Piece p = bor.piece(pos);
            return p==null||p.color!=color;
        }
         public Piece(Color color){
            this.position =null;
            this.bor = null;
            this.color = color;
            this.mvmtAmount = 0;

        }
        public Piece(Board bor,Color color){
            this.position = null;
            this.bor = bor;
            this.color = color;
            this.mvmtAmount = 0;

        }
        public abstract bool[,] possibleMovements();
        public void increasemvmtAmount(){
            mvmtAmount++;
        }        
        public void decreasemvmtAmount(){
            mvmtAmount--;
        }        
        protected bool isEnemyPiece(Position pos){
            Piece p2= bor.piece(pos);
            if(p2!=null){
                return p2.color!=color;
            }
            return false;
        }

    }
}

