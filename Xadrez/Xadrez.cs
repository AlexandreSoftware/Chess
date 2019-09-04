using System;
using tabuleiro;
using System.Threading;
using System.Collections.Generic;
namespace Xadrez {
    class Xadrez{
        bool gameIsFinished = false;
        HashSet<Peca> pecas;
        List<Peca> capturadosBrancos;
        List<Peca> capturadosPretos;
        Tabuleiro tab ;
        Cor jogadoratual;
        int turno;
        bool[,] movimentosPossiveis;
        public Cor? corXeque;
        public Xadrez(){
            this.gameIsFinished = false;
            pecas= new HashSet<Peca>();
            this.capturadosBrancos = new List<Peca>();
            this.capturadosPretos = new List<Peca>();
            this.tab = new Tabuleiro(8, 8);
            this.jogadoratual=Cor.Branco;
            this.turno=0;
            this.corXeque=null;
            this.movimentosPossiveis=null;
        }
        private void montarTela(){
            Console.Clear();
            Tela.imprimirXadrez(tab);
            if(corXeque!=null){
                System.Console.WriteLine("XEQUE da cor: "+corXeque);
            }
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
                    PosicaoXadrez init =getInit();
                    PosicaoXadrez dest= getDest(init);
                    executarJogada(init,dest);
                } 
                catch(TabuleiroException e){
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
        }
        public PosicaoXadrez getDest(PosicaoXadrez init){
            if (tab.posicaoValida(init.ToPosicao()) && tab.existePeca(init.ToPosicao())) {
                if(tab.peca(init.ToPosicao()).cor==jogadoratual){
                    Peca p1 = tab.peca(init.ToPosicao());
                    bool[,] movimentosPossiveis=p1.movimentosPossiveis();
                    Tela.posicoesPossiveis(tab,movimentosPossiveis);
                    Console.Write("Destino: ");
                    return Tela.lerPosicaoXadrez();
                            
                }
                else{
                    throw new TabuleiroException("Jogada invalida:nao e sua vez de jogar");
                }                    
            }
            else{
                throw new TabuleiroException("input invalido, tente novamente");
                                                
            }
        }
        private void executarJogada(PosicaoXadrez init,PosicaoXadrez dest){
            Peca peca = tab.peca(init.ToPosicao());
            bool[,] movimentosPossiveis= peca.movimentosPossiveis();
            Peca p=executarMovimento(movimentosPossiveis,init.ToPosicao(),dest.ToPosicao());
            checarPromocao();
            peca.incrementarQteMovimentos();
            if(estaEmXeque(adversaria(jogadoratual))){
                desfazMovimento(p,dest.ToPosicao(),init.ToPosicao());
                throw new TabuleiroException("Voce nao pode se colocar Em xeque");
            }
            else if(estaEmXeque(jogadoratual)){
                corXeque=adversaria(jogadoratual);
            }
            else{
                corXeque=null;
            }
            if(corXeque!=null){   
                gameIsFinished=testeXequeMate((Cor)corXeque);
                if(gameIsFinished){
                    throw new TabuleiroException("Jogo Finalizado, O vencedor foi: "+adversaria((Cor)corXeque));
                }
            }
            if(tab.potentialEmPassant!=null){
                tab.emPassant=tab.potentialEmPassant;
            }
            else{
                tab.emPassant=null;
                tab.emPassant=null;
            }
            turno++;
            passarturno();
        }

        private void desfazMovimento(Peca PecaCapturada,Posicao dest,Posicao init){
            if(PecaCapturada!=null){
                tab.moverPeca(dest,init);
                tab.colocarPeca(PecaCapturada,dest);
                pecas.Add(PecaCapturada);
                if(PecaCapturada.cor==Cor.Branco){
                    capturadosBrancos.Remove(PecaCapturada);
                }
                else{
                    capturadosPretos.Remove(PecaCapturada);
                }
                tab.peca(init).decrementarQteMovimentos();
            }
            else{
                tab.moverPeca(dest,init);
            }
        }
        private void adicionarPecaCapturada(Peca p2){
            if (p2!=null) {
                pecas.Remove(p2);
                if (p2.cor == Cor.Branco) {
                    capturadosBrancos.Add(p2);
                }
                else {
                    capturadosPretos.Add(p2);
                }
            }
        }
        private Peca executarMovimento(bool[,] movimentosPossiveis,Posicao init,Posicao dest){
            if(tab.emPassant!=null&&tab.peca(tab.emPassant)!=null){
                Posicao casaatraz=tab.casaAtraz(tab.emPassant);
                if(movimentosPossiveis[casaatraz.Linha,casaatraz.Coluna]&&dest.Linha==casaatraz.Linha&&dest.Coluna==casaatraz.Coluna){
                    tab.moverPeca(init,dest);
                    Peca p2=tab.retirarPeca(tab.emPassant);
                    adicionarPecaCapturada(p2);
                    return p2;
                }
            }
            if(movimentosPossiveis[dest.Linha,dest.Coluna]==true&&tab.peca(dest)!=null&&tab.peca(init).cor==tab.peca(dest).cor){
                Peca p2 = tab.moverPeca(init, dest);
                tab.colocarPeca(p2,init);
                p2.incrementarQteMovimentos();
                return null;                
            }
            else if(movimentosPossiveis[dest.Linha,dest.Coluna]==true){
                Peca p2 = tab.moverPeca(init, dest);
                adicionarPecaCapturada(p2);
                return p2;
            }
            else {
                throw new TabuleiroException("Movimento Impossivel: Destino invalido, pressione qualquer tecla para continuar");                
            }
        }
        private PosicaoXadrez getInit(){
            Console.Write("Origem: ");
            return Tela.lerPosicaoXadrez();
        }
    
        private void MontarTabuleiro(Tabuleiro tab) {
            for (char i = 'a'; i < 'h' + 1; i++) {
                adicionarPeca(new Peao(tab, Cor.Branco), new PosicaoXadrez(i, 2).ToPosicao());
                adicionarPeca(new Peao(tab, Cor.Preto), new PosicaoXadrez(i, 7).ToPosicao());
            }
            //PRETAS
            adicionarPeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('a', 8).ToPosicao());  
            adicionarPeca(new Cavalo(tab, Cor.Preto), new PosicaoXadrez('b', 8).ToPosicao());
            adicionarPeca(new Bispo(tab, Cor.Preto), new PosicaoXadrez('c', 8).ToPosicao());
            adicionarPeca(new Rainha(tab, Cor.Preto), new PosicaoXadrez('d', 8).ToPosicao());
            adicionarPeca(new Rei(tab, Cor.Preto), new PosicaoXadrez('e', 8).ToPosicao());
            adicionarPeca(new Bispo(tab, Cor.Preto), new PosicaoXadrez('f', 8).ToPosicao());
            adicionarPeca(new Cavalo(tab, Cor.Preto), new PosicaoXadrez('g', 8).ToPosicao());
            adicionarPeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('h', 8).ToPosicao());
            //BRANCAS                                                                      
            adicionarPeca(new Torre(tab, Cor.Branco), new PosicaoXadrez('a', 1).ToPosicao());
            adicionarPeca(new Cavalo(tab, Cor.Branco), new PosicaoXadrez('b', 1).ToPosicao());
            adicionarPeca(new Bispo(tab, Cor.Branco), new PosicaoXadrez('c', 1).ToPosicao());
            adicionarPeca(new Rei(tab, Cor.Branco), new PosicaoXadrez('d', 1).ToPosicao());
            adicionarPeca(new Rainha(tab, Cor.Branco), new PosicaoXadrez('e', 1).ToPosicao());
            adicionarPeca(new Bispo(tab, Cor.Branco), new PosicaoXadrez('f', 1).ToPosicao());
            adicionarPeca(new Cavalo(tab, Cor.Branco), new PosicaoXadrez('g', 1).ToPosicao());
            adicionarPeca(new Torre(tab, Cor.Branco), new PosicaoXadrez('h', 1).ToPosicao());
            Tela.imprimirXadrezdelay(tab);
        }
        private HashSet<Peca> pecasEmJogo(Cor cor){
            HashSet<Peca> pecasEmJogo=new HashSet<Peca>();
            foreach(Peca x in pecas){
                if(x.cor==cor){
                    pecasEmJogo.Add(x);
                } 
            }
            return pecasEmJogo;
        }
        public bool estaEmXeque(Cor cor){
            Peca R=rei(cor);
            Posicao realEmPassant=null;
            Posicao realPotencialEmpassant=null;
            if(tab.emPassant!=null){
                realEmPassant= new Posicao(tab.emPassant.Linha,tab.emPassant.Coluna);
            }
            if(tab.potentialEmPassant!=null){
                realPotencialEmpassant=new Posicao(tab.potentialEmPassant.Linha,tab.potentialEmPassant.Coluna);
            }
            foreach(Peca peca in pecasEmJogo(adversaria(cor))){                
                bool[,] mat=peca.movimentosPossiveis();
                tab.emPassant=realEmPassant;
                tab.potentialEmPassant=realPotencialEmpassant;
                if(mat[R.posicao.Linha,R.posicao.Coluna]&&R.cor!=peca.cor){
                    return true;
                }
            }
            return false;
        }
        public bool testeXequeMate(Cor? cor){
            if(estaEmXeque((Cor)cor)){return false;}
            foreach (Peca item in pecasEmJogo(adversaria((Cor)cor))){
                if(item.posicao!=null){
                    bool[,] mat = item.movimentosPossiveis();
                    for(int i=0;i<tab.linhas;i++){
                        for (int j = 0; j < tab.colunas; j++)
                        {
                            if(mat[i,j]){
                                Posicao init=new Posicao(item.posicao.Linha,item.posicao.Coluna);
                                Peca PecaCapturada = executarMovimento(mat,item.posicao,new Posicao(i,j));
                                bool xeque= estaEmXeque((Cor)corXeque);
                                desfazMovimento(PecaCapturada,item.posicao,init);
                                if(!xeque){
                                    return false;
                                }
                                
                            }
                        }
                    }
                }
            }
            return true;
        }
        private void checarPromocao(){
            for (int i = 0; i < tab.colunas; i++)
            {
                Peca branca=tab.peca(0,i);
                if(branca!=null&&branca is Peao&& branca.cor==Cor.Branco){
                    promocao(new Posicao(0,i));
                }
                Peca preta=tab.peca(7,i);
                if(preta!=null&&preta is Peao&& preta.cor==Cor.Preto){
                    promocao(new Posicao(0,i));
                }
            }
        }
        private void promocao(Posicao dest){
            bool val=true;
            while(val){
            Console.Clear();
            Tela.imprimirXadrezdelay(tab);
            Console.WriteLine("PROMOCÃO: Escolha a peca:");
            Console.WriteLine("1-Torre\n2-Bispo\n3-Cavalo\n4-Dama");
            char a =Console.ReadKey().KeyChar;
            if(Char.IsDigit(a)){
               
                Peca temp;
                Posicao pos = new Posicao(dest.Linha,dest.Coluna);
                if(int.TryParse(a.ToString(),out int i)){
                    
                    
                        switch (i)
                        {
                            case 1:
                                temp =tab.retirarPeca(dest);
                                pecas.Remove(temp);                                
                                adicionarPeca(new Torre(tab,temp.cor),pos);
                                while(temp.qteMovimentos!=tab.peca(dest).qteMovimentos){
                                    tab.peca(dest).incrementarQteMovimentos();
                                }
                                val=false;
                            break;
                            case 2:
                                temp =tab.retirarPeca(dest);
                                pecas.Remove(temp);                                
                                adicionarPeca(new Bispo(tab,temp.cor),pos);
                                while(temp.qteMovimentos!=tab.peca(dest).qteMovimentos){
                                    tab.peca(dest).incrementarQteMovimentos();
                                }
                                val=false;
                            break;
                            case 3:
                                temp =tab.retirarPeca(dest);
                                pecas.Remove(temp);                                
                                adicionarPeca(new Cavalo(tab,temp.cor),pos);
                                while(temp.qteMovimentos!=tab.peca(dest).qteMovimentos){
                                    tab.peca(dest).incrementarQteMovimentos();
                                }
                                val=false;
                            break;
                            
                            case 4:
                                temp =tab.retirarPeca(dest);
                                pecas.Remove(temp);                                
                                adicionarPeca(new Rainha(tab,temp.cor),pos);
                                while(temp.qteMovimentos!=tab.peca(dest).qteMovimentos){
                                    tab.peca(dest).incrementarQteMovimentos();
                                }
                                val=false;
                            break;
                            
                            default:
                                Console.WriteLine("ERRO: Input Invalido");
                            break;
                            
                            
                        }
                    }
                }
            }
        }

        private void adicionarPeca(Peca peca, Posicao pos){
            tab.colocarPeca(peca,pos);
            pecas.Add(peca);
        }
        private void passarturno(){jogadoratual=jogadoratual==Cor.Branco?Cor.Preto:Cor.Branco;}
        private Rei rei(Cor cor){
            foreach (Peca peca in pecas)
            {
                if(peca is Rei&&peca.cor==cor){
                    return (Rei)peca;
                }
            }
            throw new TabuleiroException("Nao existe Um rei dessa cor: isso realmente nao deveria estar acontecendo");
        }
        private Cor adversaria(Cor cor){return cor==Cor.Branco? Cor.Preto:Cor.Branco;}
    } 
}

