namespace BoardNS {
    class Board {
        public int lines { get; private set; }
        public int columns { get; private set; }
        private Piece[,] pieces;
        public Position potentialEmPassant;
        public Position emPassant;
        public Tabuleiro(int lines, int columns) {
            this.columns = columns;
            this.lines = lines;
            Pieces = new Piece[lines, columns];
            
        }
        public Position squareBefore(Position pos){
            if(Piece(pos).color==color.White){
                return new Position(pos.line+1,pos.column);
            }
            else{
                return new Position(pos.line-1,pos.column);
            }
        }

        public bool pieceExists(Position pos)=>Piece(pos) != null;
        public Piece Piece(Position pos)=>Pieces[pos.line,pos.column];
        public Piece Piece(int line, int column)=>Pieces[line, column];
        public void putPiece(Piece p, Position pos) {
            if(pieceExists(pos)){
                throw new TabuleiroException("Ja existe uma peça nessa posiçao");
            }
            
            Pieces[pos.line, pos.column] = p;
            p.Position = pos;
            
        }
        public bool validPosition(Position pos) {
            if (pos.line<0||pos.line>=lines||pos.column<0||pos.column>=columns) {
                return false;
            }
            return true;
        }
        

        public Piece withdrawPiece(Position pos) {
            if (Piece(pos) == null) {
                return null;
            }

            Piece aux = Piece(pos);
            aux.Position = null;
            Pieces[pos.line, pos.column] = null;
            return aux;
        }
        public Piece movePiece(Position initPos,Position endPos) {
            
            if (validPosition(endPos)) {
                Piece p1;   
                p1 = withdrawPiece(endPos);
                putPiece(Piece(initPos),endPos);
                withdrawPiece(initPos);
                Piece(endPos).Position=endPos;
                return p1;
            }          
            return null;
        }
        public void validatePosition(Position pos) {
            if (!validPosition(pos)&&!existePiece(pos)==false) {
                throw new TabuleiroException("Posição Invalida!"); 
            }
        }
    }
}
