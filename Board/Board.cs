namespace BoardNS {
    class Board {
        public int lines { get; private set; }
        public int columns { get; private set; }
        private Piece[,] pieces;
        public Position potentialEmPassant;
        public Position emPassant;
        public Board(int lines, int columns) {
            this.columns = columns;
            this.lines = lines;
            pieces = new Piece[lines, columns];
            
        }
        public Position squareBefore(Position pos)=>
         piece(pos).color==Color.White?
         new Position(pos.line+1,pos.column) :
         new Position(pos.line-1,pos.column);

        public bool pieceExists(Position pos)=>piece(pos) != null;
        public Piece piece(Position pos)=>pieces[pos.line,pos.column];
        public Piece piece(int line, int column)=>pieces[line, column];
        public void putPiece(Piece p, Position pos) 
        {
            if(pieceExists(pos)) throw new BoardException("There's already a piece in this position");
            pieces[pos.line, pos.column].position=pos;
        }
        public bool validPosition(Position pos)=>pos.line<0||pos.line>=lines||pos.column<0||pos.column>=columns?false: true;

        public Piece withdrawPiece(Position pos) {
            if (piece(pos) == null)
                return null;
            Piece aux = piece(pos);
            aux.position = null;
            pieces[pos.line, pos.column] = null;
            return aux;
        }
        public Piece movepiece(Position initPos,Position endPos) {
            
            if (validPosition(endPos)) {
                Piece p1;   
                p1 = withdrawPiece(endPos);
                putPiece(piece(initPos),endPos);
                withdrawPiece(initPos);
                piece(endPos).position=endPos;
                return p1;
            }          
            return null;
        }
        public void validatePosition(Position pos){
            if (!validPosition(pos)&&!pieceExists(pos)==false)
                throw new BoardException("Invalid Position!"); 
        }
    }
}
