using System;
using tabuleiro;
using System.Threading;
using System.Collections.Generic;
namespace Xadrez {
    class Xadrez : Game {
        public override void GameLoop() {
            bool gameisfinished = false;
            PosicaoXadrez init;
            List<Peca> capturadosbrancos = new List<Peca>();
            List<Peca> capturadospretos = new List<Peca>();
            Tabuleiro tab = new Tabuleiro(8, 8);
            MontarTabuleiro(tab);
            Console.Clear();
            while (!gameisfinished) {
                Tela.imprimirxadrez(tab);
                foreach (Peca item in capturadosbrancos) {
                    Console.Write(item);
                }
                foreach (Peca item in capturadospretos) {
                    Console.Write(item);
                }
                
                init = Tela.lerPosicaoXadrez();
                Peca p1 = tab.peca(init.ToPosicao());
                Console.Write("\r");
                if (tab.posicaovalida(init.ToPosicao()) && tab.existepeca(init.ToPosicao())) {
                    
                    PosicaoXadrez target = Tela.lerPosicaoXadrez();

                    Peca p2 = tab.MoverPeca(p1, init.ToPosicao(), target.ToPosicao());
                    if (tab.posicaovalida(target.ToPosicao()) && tab.existepeca(target.ToPosicao())) {

                        Cor p2cor = p2.cor;
                        if (p2cor == Cor.Branco) {
                            capturadosbrancos.Add(p2);
                        }
                        else {
                            capturadospretos.Add(p2);
                        }
                    }
                    else {
                        Console.WriteLine("input invalido, tente novamente");
                    }
                }
            }
        }

    public static void MontarTabuleiro(Tabuleiro tab) {
        Tela.imprimirtabuleiro(tab);
        for (char i = 'a'; i < 'h' + 1; i++) {
            tab.Colocarpeca(new Peao(tab, Cor.Branco), new PosicaoXadrez(i, 2).ToPosicao());
            tab.Colocarpeca(new Peao(tab, Cor.Preto), new PosicaoXadrez(i, 7).ToPosicao());
        }
        //PRETAS
        tab.Colocarpeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('a', 8).ToPosicao());
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
        Tela.imprimirxadrezdelay(tab);

    }

} 
}

