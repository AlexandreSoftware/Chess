

namespace BoardNS
{
    public class ChessPosition
    { 

        public char column { get; set; }
        public int line { get; set; }
        
        public Position ToPosition(){
            return new Position(8-line,column-'a');
        }
        public ChessPosition(char column,int line){
            this.line=line;
            this.column=column;
        }
        public override string ToString(){
            return "" +column+line;
        }   
    }
}
