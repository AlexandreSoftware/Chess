namespace BoardNS.Pieces {
    class Queen : Piece {
        public Queen(Board bor, Color color) : base(bor, color) {

        }
        public override bool[,] possibleMovements(){
            bool validator=true;
            bool[,] mat=new bool[bor.lines,bor.columns];
            Position pos= new Position(position.line,position.column);
            //East
            while(validator==true){
                pos.defineValues(pos.line,pos.column-1);
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
            validator=true;
            //WEST
            pos.defineValues(position.line,position.column);
            while(validator==true){
                pos.defineValues(pos.line,pos.column+1);
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
            //North
            validator=true;
            pos.defineValues(position.line,position.column);
            while(validator==true){
                pos.defineValues(pos.line-1,pos.column);
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
            //South
            validator=true;
            pos.defineValues(position.line,position.column);
            while(validator==true){
                pos.defineValues(pos.line+1,pos.column);
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
            //SEk
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
            return "Q";
        }
    }
}
