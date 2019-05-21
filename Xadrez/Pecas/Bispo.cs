using System.Collections.Generic;
using tabuleiro;

namespace Xadrez {
    class Bispo : Peca{
        public Bispo(Tabuleiro tab,Cor cor): base(tab,cor) {
            
        }
        public override bool[,] movimentosPossiveis(){
            
            return null;
        }
        public override string ToString() {
                return "B";
            }
        }
}
