namespace BoardNS.Pieces {
    class King: Piece{
        public King(Board bor,Color color): base(bor,color) {

        }
        public override bool[,] possibleMovements(){
            bool[,] mat = new  bool[bor.lines,bor.columns];
            Position pos=new Position(0,0);
            //topo
            pos.defineValues(position.line-1,position.column);  
            if(bor.validPosition(pos)&&canMove(pos)){
                mat[pos.line,pos.column]=true;
            }
            //esquerda
            pos.defineValues(position.line,position.column-1);
            if(bor.validPosition(pos)&&canMove(pos)){
                
                mat[pos.line,pos.column]=true;
            }
            //direita
            pos.defineValues(position.line,position.column+1);
            if(bor.validPosition(pos)&&canMove(pos)){ 
                mat[pos.line,pos.column]=true;
            }
            //ne
            pos.defineValues(position.line-1,position.column-1);
            if(bor.validPosition(pos)&&canMove(pos)){
                mat[pos.line,pos.column]=true;
            }
            //nw
            pos.defineValues(position.line-1,position.column+1);
            if(bor.validPosition(pos)&&canMove(pos)){
                mat[pos.line,pos.column]=true;
            }
            //sul
            pos.defineValues(position.line+1,position.column);
            if(bor.validPosition(pos)&&canMove(pos)){
                mat[pos.line,pos.column]=true;
            }
            //se
            pos.defineValues(position.line+1,position.column-1);
            if(bor.validPosition(pos)&&canMove(pos)){
                
                mat[pos.line,pos.column]=true;
            }
            //sw
            pos.defineValues(position.line+1,position.column+1); 
            if(bor.validPosition(pos)&&canMove(pos)){
                
                mat[pos.line,pos.column]=true;
            }
            pos.defineValues(position.line,position.column);
            //Roque
            if(mvmtAmount==0){
                bool validator=true;
                while(validator==true){
                    pos.defineValues(pos.line,pos.column-1);
                    if(bor.validPosition(pos)&&bor.piece(pos) is Tower&&bor.piece(pos).mvmtAmount==0&&bor.piece(pos).color==color){
                        mat[pos.line,pos.column]=true;
                    }
                    if(bor.validPosition(pos)&&!canMove(pos)){
                        validator=false;
                    }
                    else if(!bor.validPosition(pos)==true){
                        validator=false;
                    }
                }
                validator=true;
                pos.defineValues(position.line,position.column);
                while(validator==true){
                    pos.defineValues(pos.line,pos.column+1);
                    if(bor.validPosition(pos)&&bor.piece(pos) is Tower&&bor.piece(pos).mvmtAmount==0&&bor.piece(pos).color==color){
                        mat[pos.line,pos.column]=true;
                    }
                    if(bor.validPosition(pos)&&!canMove(pos)){
                        validator=false;
                    }
                    else if(!bor.validPosition(pos)==true){
                        validator=false;
                    }
                }
            }
            //
            return mat;
        }
        public override string ToString() {
            return "R";
        }
    }
}
