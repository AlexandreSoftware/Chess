using tabuleiro;
namespace Xadrez {
    class Rainha : Peca {
        public Rainha(Tabuleiro tab, Cor cor) : base(tab, cor) {

        }
        public override string ToString() {
            return "Q";
        }
    }
}
