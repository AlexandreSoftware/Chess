using System;
using tabuleiro;
using System.Threading;
using System.IO;
namespace Xadrez {
    class Tela {
        public static void imprimirXadrez(Tabuleiro tab) {
            Console.Clear();
            for (int i = 0; i < tab.linhas; i++) {
                System.Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++) {
                    if (tab.peca(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        Tela.imprimirPeca(tab.peca(i, j));
                        Console.Write(" ");
                    }

                }

                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void imprimirTabuleiro(Tabuleiro tab) {
            Console.Clear();
            for (int i = 0; i < tab.linhas; i++) {
                
                for (int j = 0; j < tab.colunas; j++) {
                    if (tab.peca(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        imprimirPeca(tab.peca(i, j));
                        Console.Write(" ");
                    }

                }

                Console.WriteLine();
            }
         }
         public static void posicoesPossiveis(Tabuleiro tab,bool[,] tabpossivel) {
            Console.Clear();
            if(tabpossivel!=null){
            for (int i = 0; i < tab.linhas; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++) {
                    if (tab.peca(i, j) == null&&tabpossivel[i,j]==false) {
                        
                        Console.Write("- ");
                    }
                    else if (tab.peca(i, j) == null&&tabpossivel[i,j]==true) {
                        ConsoleColor actualConsoleColor=Console.BackgroundColor;
                        Console.BackgroundColor=ConsoleColor.Blue;
                        Console.Write("- ");
                        Console.BackgroundColor=actualConsoleColor;
                    }
                    else if(tab.peca(i, j) == null&&tabpossivel[i,j]==true){
                        ConsoleColor actualConsoleColor=Console.BackgroundColor;
                        Console.BackgroundColor=ConsoleColor.Blue;
                        Console.Write("- ");
                        Console.BackgroundColor=actualConsoleColor;
                    }
                    else {
                        Tela.imprimirPeca(tab.peca(i, j));
                        Console.Write(" ");
                    }
                    
                }
                Console.WriteLine();
            }
                    Console.WriteLine("  a b c d e f g h");
            }
            else{
                throw new TabuleiroException("ERRO:nao existe uma matriz");
            }
            
        }
        public static void imprimirPeca(Peca peca) {
            if (peca.cor == Cor.Branco) {
                System.Console.Write(peca);
            }
            else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
        public static PosicaoXadrez lerPosicaoXadrez() {
            string s = Console.ReadLine();
            s=s.ToLower();
            if (s == "exit") {
                Environment.Exit(0);
                return null;
            }
            if(s==""||s==null){
                throw new TabuleiroException("Input invalido: tente novamente");
            }
            else {
                
                char coluna = s[0];
                int linha = int.Parse(s[1] + "");
                return new PosicaoXadrez(coluna, linha);
            }
        }
        
        public static void imprimirXadrezdelay(Tabuleiro tab){
            Console.Clear();
            for (int i = 0; i < tab.linhas; i++) {
                Thread.Sleep(10);
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++) {
                    Thread.Sleep(10);
                    if (tab.peca(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        Tela.imprimirPeca(tab.peca(i, j));
                        Console.Write(" ");
                    }

                }

                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        
    }
}
