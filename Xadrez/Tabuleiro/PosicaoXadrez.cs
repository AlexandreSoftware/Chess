using tabuleiro;

namespace Xadrez
{
    public class PosicaoXadrez
    { 

        public char Coluna { get; set; }
        public int Linha { get; set; }
        
        public Posicao ToPosicao(){
            return new Posicao(8-Linha,Coluna-'a');
        }
        public PosicaoXadrez(char Coluna,int Linha){
            this.Linha=Linha;
            this.Coluna=Coluna;
        }
        public override string ToString(){
            return "" +Coluna+Linha;
        }   
    }
}
