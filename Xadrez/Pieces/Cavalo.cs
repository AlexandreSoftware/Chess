namespace BoardNS.Pieces {
    class Horse : Piece {
        public Horse(Board bor, Color color) : base(bor, color) {

        }
        public override bool[,] possibleMovements(){
            bool[,] mat = new  bool[bor.lines,bor.columns];
            Position pos=new Position(0,0);
            //ne
            pos.defineValues(position.line-2,position.column-1);  
            if(bor.validPosition(pos)&&canMove(pos)){
                mat[pos.line,pos.column]=true;
            }
            //nw
            pos.defineValues(position.line-2,position.column+1);
            if(bor.validPosition(pos)&&canMove(pos)){
                
                mat[pos.line,pos.column]=true;
            }
            //se
            pos.defineValues(position.line+2,position.column-1);
            if(bor.validPosition(pos)&&canMove(pos)){ 
                mat[pos.line,pos.column]=true;
            }
            //sw
            pos.defineValues(position.line+2,position.column+1);
            if(bor.validPosition(pos)&&canMove(pos)){
                mat[pos.line,pos.column]=true;
            }
            //en
            pos.defineValues(position.line+1,position.column-2);
            if(bor.validPosition(pos)&&canMove(pos)){
                mat[pos.line,pos.column]=true;
            }
            //es
            pos.defineValues(position.line+1,position.column+2);
            if(bor.validPosition(pos)&&canMove(pos)){
                mat[pos.line,pos.column]=true;
            }
            //wn
            pos.defineValues(position.line-1,position.column-2);
            if(bor.validPosition(pos)&&canMove(pos)){
                mat[pos.line,pos.column]=true;
            }
            //ws
            pos.defineValues(position.line-1,position.column+2);
            if(bor.validPosition(pos)&&canMove(pos)){
                mat[pos.line,pos.column]=true;
            }
            return mat;
        }
        public override string ToString() {
            return "C";
        }
    }
}
