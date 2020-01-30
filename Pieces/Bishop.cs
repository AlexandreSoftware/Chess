namespace BoardNS.Pieces {
    class Bishop : Piece{
        public Bishop(Board bor,Color color): base(bor,color) {
            
        }
        public override bool[,] possibleMovements(){
            bool validator=true;
            bool[,] mat=new bool[bor.lines,bor.columns];
            Position pos= new Position(position.line,position.column);
            //NE
            validator=true;
            pos.defineValues(position.line,position.column);
            while(validator==true){
                pos.defineValues(pos.line-1,pos.column-1);
                if(bor.validPosition(pos)&&canMove(pos)&&isEnemyPiece(pos)){
                    mat[pos.line,pos.column]=true;
                    validator=false;
                }
                else if(bor.validPosition(pos)&&canMove(pos)){
                    mat[pos.line,pos.column]=true;
                }
                else if(bor.validPosition(pos)==true&&canMove(pos)==false){
                    validator=false;
                }
                else{
                    validator=false;
                }
            }
            //NW
            validator=true;
            pos.defineValues(position.line,position.column);
            while(validator==true){
                pos.defineValues(pos.line-1,pos.column+1);
                if(bor.validPosition(pos)&&canMove(pos)&&isEnemyPiece(pos)){
                    mat[pos.line,pos.column]=true;
                    validator=false;
                }
                else if(bor.validPosition(pos)&&canMove(pos)){
                    mat[pos.line,pos.column]=true;
                }
                else if(bor.validPosition(pos)==true&&canMove(pos)==false){
                    validator=false;
                }
                else{
                    validator=false;
                }
            }
            //SE
            pos.defineValues(position.line,position.column);
            validator=true;
            while(validator==true){
                pos.defineValues(pos.line+1,pos.column-1);
                if(bor.validPosition(pos)&&canMove(pos)&&isEnemyPiece(pos)){
                    mat[pos.line,pos.column]=true;
                    validator=false;
                }
                else if(bor.validPosition(pos)&&canMove(pos)){
                    mat[pos.line,pos.column]=true;
                }
                else if(bor.validPosition(pos)==true&&canMove(pos)==false){
                    validator=false;
                }
                else{
                    validator=false;
                }
            }
            //SW
            pos.defineValues(position.line,position.column);
            validator=true;
            while(validator==true){
                pos.defineValues(pos.line+1,pos.column+1);
                if(bor.validPosition(pos)&&canMove(pos)&&isEnemyPiece(pos)){
                    mat[pos.line,pos.column]=true;
                    validator=false;
                }
                else if(bor.validPosition(pos)&&canMove(pos)){
                    mat[pos.line,pos.column]=true;
                }
                else if(bor.validPosition(pos)==true&&canMove(pos)==false){
                    validator=false;
                }
                else{
                    validator=false;
                }
            }
            
            return mat;
        }
        public override string ToString() {
                return "B";
            }
        }
}
