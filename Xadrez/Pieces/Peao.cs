namespace BoardNS.Pieces {
    class Pawn : Piece {
        public Pawn(Board bor, Color color) : base(bor, color) {

        }
        public override bool[,] possibleMovements(){
            bool[,] mat= new bool[bor.lines,bor.columns];
            Position pos=new Position(0,0);
            pos.defineValues(position.line,position.column);
            if(bor.emPassant!=null){
                pos.defineValues(position.line,position.column-1);
                if(pos.line==bor.emPassant.line&&pos.column==bor.emPassant.column){
                    Position posa = bor.squareBefore(bor.emPassant);
                    mat[posa.line,posa.column]=true;
                }
                pos.defineValues(position.line,position.column+1);
                if(pos.line==bor.emPassant.line&&pos.column==bor.emPassant.column){
                    Position posa = bor.squareBefore(bor.emPassant);
                    mat[posa.line,posa.column]=true;
                }
            }
            pos.defineValues(position.line,position.column);            
            if(color==Color.White){
                pos.defineValues(position.line-1,position.column);
                if(bor.validPosition(pos)&&canMove(pos)&&!bor.pieceExists(pos)){
                    mat[pos.line,pos.column]=true;
                }
                pos.defineValues(pos.line,pos.column-1);
                if(bor.validPosition(pos)&&canMove(pos)&&bor.pieceExists(pos)){
                        mat[pos.line,pos.column]=true;
                }
                pos.defineValues(pos.line,pos.column+2);
                if(bor.validPosition(pos)&&canMove(pos)&&bor.pieceExists(pos)){
                        mat[pos.line,pos.column]=true;
                }
                if(mvmtAmount==0){
                    pos.defineValues(position.line-2,position.column);
                    if(bor.validPosition(pos)&&canMove(pos)&&!bor.pieceExists(pos)){
                        mat[pos.line,pos.column]=true;
                        bor.potentialEmPassant=new Position(pos.line,pos.column);
                    }
                }            
                
            }
            else{
                pos.defineValues(position.line+1,position.column);
                if(bor.validPosition(pos)&&canMove(pos)&&!bor.pieceExists(pos)){
                    mat[pos.line,pos.column]=true;
                }
                pos.defineValues(pos.line,pos.column-1);
                if(bor.validPosition(pos)&&canMove(pos)&&bor.pieceExists(pos)){
                    mat[pos.line,pos.column]=true;
                }
                pos.defineValues(pos.line,pos.column+2);
                if(bor.validPosition(pos)&&canMove(pos)&&bor.pieceExists(pos)){
                    mat[pos.line,pos.column]=true;
                }
                if(mvmtAmount==0){
                    pos.defineValues(position.line+2,position.column);
                    if(bor.validPosition(pos)&&canMove(pos)&&!bor.pieceExists(pos)){
                        mat[pos.line,pos.column]=true;
                        bor.potentialEmPassant=new Position(pos.line,pos.column);
                    }
                }
            }
            return mat;
        }
        public override string ToString() {
            return "P";
        }
    }
}
