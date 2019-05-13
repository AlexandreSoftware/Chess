using System;
using tabuleiro;
using System.Threading;
namespace Xadrez {
    class Xadrez: Game {
        public static void MontarTabuleiro(Tabuleiro tab) {
            Tela.imprimirtabuleiro(tab);
            for (char i = 'a'; i < 'h' + 1; i++) {
                Console.Clear();

                tab.Colocarpeca(new Peao(tab, Cor.Branco), new PosicaoXadrez(i, 2).ToPosicao());
                tab.Colocarpeca(new Peao(tab, Cor.Preto), new PosicaoXadrez(i, 7).ToPosicao());
            }
            //PRETAS
            tab.Colocarpeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('a',8).ToPosicao());
            tab.Colocarpeca(new Cavalo(tab, Cor.Preto), new PosicaoXadrez('b', 8).ToPosicao());
            tab.Colocarpeca(new Bispo(tab, Cor.Preto), new PosicaoXadrez('c', 8).ToPosicao());
            tab.Colocarpeca(new Rainha(tab, Cor.Preto), new PosicaoXadrez('d', 8).ToPosicao());
            tab.Colocarpeca(new Rei(tab, Cor.Preto), new PosicaoXadrez('e', 8).ToPosicao());
            tab.Colocarpeca(new Bispo(tab, Cor.Preto), new PosicaoXadrez('f', 8).ToPosicao());
            tab.Colocarpeca(new Cavalo(tab, Cor.Preto), new PosicaoXadrez('g', 8).ToPosicao());
            tab.Colocarpeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('h', 8).ToPosicao());
            //BRANCAS
            tab.Colocarpeca(new Torre(tab, Cor.Branco), new PosicaoXadrez('a', 1).ToPosicao());
            tab.Colocarpeca(new Cavalo(tab, Cor.Branco), new PosicaoXadrez('b', 1).ToPosicao());
            tab.Colocarpeca(new Bispo(tab, Cor.Branco), new PosicaoXadrez('c', 1).ToPosicao());
            tab.Colocarpeca(new Rei(tab, Cor.Branco), new PosicaoXadrez('d', 1).ToPosicao());
            tab.Colocarpeca(new Rainha(tab, Cor.Branco), new PosicaoXadrez('e', 1).ToPosicao());
            tab.Colocarpeca(new Bispo(tab, Cor.Branco), new PosicaoXadrez('f', 1).ToPosicao());
            tab.Colocarpeca(new Cavalo(tab, Cor.Branco), new PosicaoXadrez('g', 1).ToPosicao());
            tab.Colocarpeca(new Torre(tab, Cor.Branco), new PosicaoXadrez('h', 1).ToPosicao());
            Tela.imprimirtabuleirodelay(tab);
            
        }
    }
}
