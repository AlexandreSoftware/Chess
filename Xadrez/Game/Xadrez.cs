using System;
using tabuleiro;
using System.Threading;
using System.Collections.Generic;
namespace Xadrez {
    class Xadrez : Game {
        public override void GameLoop() {
            bool gameIsFinished = false;
            PosicaoXadrez init;
            List<Peca> capturadosBrancos = new List<Peca>();
            List<Peca> capturadosPretos = new List<Peca>();
            Tabuleiro tab = new Tabuleiro(8, 8);
            Cor jogadoratual=Cor.Branco;
            MontarTabuleiro(tab);

            Console.Clear();
            while (!gameIsFinished) {
                
                Tela.imprimirxadrez(tab);
                Console.Write("PECAS Brancas:[");
                foreach (Peca item in capturadosBrancos) {
                    Console.Write(item+" ");
                }
                ConsoleColor consoleColor=Console.ForegroundColor;
                Console.Write("]\n");
                Console.ForegroundColor=ConsoleColor.Yellow;
                Console.Write("Pecas Pretas:[");
                foreach (Peca item in capturadosPretos) {
                    Console.Write(item+" ");
                }
                Console.Write("]");
                Console.ForegroundColor=consoleColor;
                Console.WriteLine();
                try{
                    Console.Write("Origem: ");
                    init = Tela.lerPosicaoXadrez();
                    if (tab.posicaovalida(init.ToPosicao()) && tab.existepeca(init.ToPosicao())) {
                        if(tab.peca(init.ToPosicao()).cor==jogadoratual){
                            Peca p1 = tab.peca(init.ToPosicao());
                            bool[,]movimentospossivels=p1.movimentosPossiveis();
                            Tela.posicoesPossiveis(tab,movimentospossivels);
                            Console.Write("Destino: ");
                            PosicaoXadrez destino = Tela.lerPosicaoXadrez();
                            if(movimentospossivels[destino.Linha,destino.Linha]==true){
                                Peca p2 = tab.MoverPeca(init.ToPosicao(), destino.ToPosicao());
                                if (p2!=null) {
                                    Cor p2cor = p2.cor;
                                    if (p2cor == Cor.Branco) {
                                        capturadosBrancos.Add(p2);
                                    }
                                    else {
                                        capturadosPretos.Add(p2);
                                    }
                                }
                                
                            }
                            else {
                                Console.WriteLine("Movimento Impossivel: Destino invalido, pressione qualquer tecla para continuar");            
                                Console.ReadKey();
                            }
                        
                        }
                        else{
                            throw new TabuleiroException("Jogada invalida:nao e sua vez de jogar");
                        }                    
                    }
                    
                        
                        
                        else{
                            Console.WriteLine("input invalido, tente novamente");
                            Console.ReadKey();
                                
                        }
                }
                catch(TabuleiroException e){
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                }
            }

        }

    public static void MontarTabuleiro(Tabuleiro tab) {
        Tela.imprimirtabuleiro(tab);
        for (char i = 'a'; i < 'h' + 1; i++) {
            tab.colocarPeca(new Peao(tab, Cor.Branco), new PosicaoXadrez(i, 2).ToPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Preto), new PosicaoXadrez(i, 7).ToPosicao());
        }
        //PRETAS
        tab.colocarPeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('a', 8).ToPosicao());
        tab.colocarPeca(new Cavalo(tab, Cor.Preto), new PosicaoXadrez('b', 8).ToPosicao());
        tab.colocarPeca(new Bispo(tab, Cor.Preto), new PosicaoXadrez('c', 8).ToPosicao());
        tab.colocarPeca(new Rainha(tab, Cor.Preto), new PosicaoXadrez('d', 8).ToPosicao());
        tab.colocarPeca(new Rei(tab, Cor.Preto), new PosicaoXadrez('e', 8).ToPosicao());
        tab.colocarPeca(new Bispo(tab, Cor.Preto), new PosicaoXadrez('f', 8).ToPosicao());
        tab.colocarPeca(new Cavalo(tab, Cor.Preto), new PosicaoXadrez('g', 8).ToPosicao());
        tab.colocarPeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('h', 8).ToPosicao());
        //BRANCAS
        tab.colocarPeca(new Torre(tab, Cor.Branco), new PosicaoXadrez('a', 1).ToPosicao());
        tab.colocarPeca(new Cavalo(tab, Cor.Branco), new PosicaoXadrez('b', 1).ToPosicao());
        tab.colocarPeca(new Bispo(tab, Cor.Branco), new PosicaoXadrez('c', 1).ToPosicao());
        tab.colocarPeca(new Rei(tab, Cor.Branco), new PosicaoXadrez('d', 1).ToPosicao());
        tab.colocarPeca(new Rainha(tab, Cor.Branco), new PosicaoXadrez('e', 1).ToPosicao());
        tab.colocarPeca(new Bispo(tab, Cor.Branco), new PosicaoXadrez('f', 1).ToPosicao());
        tab.colocarPeca(new Cavalo(tab, Cor.Branco), new PosicaoXadrez('g', 1).ToPosicao());
        tab.colocarPeca(new Torre(tab, Cor.Branco), new PosicaoXadrez('h', 1).ToPosicao());
        Tela.imprimirxadrezdelay(tab);

    }
    static void passarturno(Cor jogadoratual){
        if(jogadoratual==Cor.Branco){
            jogadoratual=Cor.Preto;
        }
        if(jogadoratual==Cor.Preto){
            jogadoratual=Cor.Branco;
        }
    }
} 
}

