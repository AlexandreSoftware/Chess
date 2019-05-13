using System;
using tabuleiro;
using System.Threading;

namespace Xadrez {
    class Tela {
        public static void imprimirtabuleiro(Tabuleiro tab) {
            Console.Clear();
            for (int i = 0; i < tab.linhas; i++) {
                    System.Console.Write(8-i+" ");
                for (int j = 0; j < tab.colunas; j++) {
                    if (tab.peca(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        Tela.imprimirPeca(tab.peca(i,j));
                        Console.Write(" ");
                    }
                    
                }
            
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
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
        public static void imprimirtabuleirodelay(Tabuleiro tab){
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
