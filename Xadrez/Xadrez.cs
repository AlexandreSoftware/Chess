using System;
using tabuleiro;
using System.Threading;
using System.Collections.Generic;
namespace Xadrez {
    class Xadrez{
        bool gameIsFinished = false;
        PosicaoXadrez init;
        List<Peca> capturadosBrancos = new List<Peca>();
        List<Peca> capturadosPretos = new List<Peca>();
        Tabuleiro tab = new Tabuleiro(8, 8);
        Cor jogadoratual=Cor.Branco;
        int turno=0;
        PosicaoXadrez dest;
 
        public Xadrez(){
            this.gameIsFinished = false;
            this.init=null;
            this.capturadosBrancos = new List<Peca>();
            this.capturadosPretos = new List<Peca>();
            this.tab = new Tabuleiro(8, 8);
            this.jogadoratual=Cor.Branco;
            this.turno=0;
            this.dest=null;
        }
        private void montarTela(){
            Console.Clear();
            Tela.imprimirXadrez(tab);
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
            Console.WriteLine("\nJogador atual: {0}",jogadoratual);
            System.Console.WriteLine("Turno:{0}",turno);
        }  
        public void GameLoop() {
            MontarTabuleiro(tab);
            while (!gameIsFinished) {
                montarTela();
                try{
                    getInit();
                    bool[,] movimentosPossiveis = getDest();
                    executarJogada(movimentosPossiveis);
                }
                catch(TabuleiroException e){
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
        }
        public bool[,] getDest(){
            if (tab.posicaoValida(init.ToPosicao()) && tab.existePeca(init.ToPosicao())) {
                if(tab.peca(init.ToPosicao()).cor==jogadoratual){
                    Peca p1 = tab.peca(init.ToPosicao());
                    bool[,] movimentosPossiveis=p1.movimentosPossiveis();
                    Tela.posicoesPossiveis(tab,movimentosPossiveis);
                    Console.Write("Destino: ");
                    dest = Tela.lerPosicaoXadrez();
                    return movimentosPossiveis;       
                }
                else{
                    throw new TabuleiroException("Jogada invalida:nao e sua vez de jogar");
                }                    
            }
            else{
                throw new TabuleiroException("input invalido, tente novamente");
                                                
            }
        }
        private void executarJogada(bool[,] movimentosPossiveis){
            executarMovimento(movimentosPossiveis);
            //checarxeque e as besteirinha
            tab.peca(dest.ToPosicao().Linha,dest.ToPosicao().Coluna).incrementarQteMovimentos();
            passarturno();
        }
        private void adicionarPecaCapturada(Peca p2){
            if (p2!=null) {
                if (p2.cor == Cor.Branco) {
                    capturadosBrancos.Add(p2);
                }
                else {
                    capturadosPretos.Add(p2);
                }
            }
        }
        private Peca executarMovimento(bool[,] movimentosPossiveis){
            if(movimentosPossiveis[dest.ToPosicao().Linha,dest.ToPosicao().Coluna]==true){
                Peca p2 = tab.moverPeca(init.ToPosicao(), dest.ToPosicao());
                return p2;
            }
            else {
                throw new TabuleiroException("Movimento Impossivel: Destino invalido, pressione qualquer tecla para continuar");            
                
            }
        }
        private void getInit(){
            Console.Write("Origem: ");
            this.init = Tela.lerPosicaoXadrez();
        }
        private static void MontarTabuleiro(Tabuleiro tab) {
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
            Tela.imprimirXadrezdelay(tab);

        }
        private void passarturno(){
            if(jogadoratual==Cor.Branco){
                jogadoratual=Cor.Preto;
            }
            else if(jogadoratual==Cor.Preto){
                jogadoratual=Cor.Branco;
            }
        }
    } 
}

