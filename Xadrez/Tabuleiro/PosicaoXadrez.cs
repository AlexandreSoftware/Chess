using System;

namespace Xadrez
{
    public class PosicaoXadrez
    { 

        public char Coluna { get; set; }
        public int Linha { get; set; }
        public PosicaoXadrez(char Coluna,int Linha){
            this.Linha=Linha;
            this.Coluna=Coluna;
        }
        public override string ToString(){
            return "" +Linha+Coluna;
        }   
    }
}
