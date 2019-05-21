using tabuleiro;

namespace Xadrez {
    class Torre : Peca{
        public Torre(Tabuleiro tab,Cor cor): base(tab,cor) {

        }
        public override bool[,] movimentosPossiveis(){
            
            return null;
        }
        public override string ToString() {
            return "T";
        }
    }
}
