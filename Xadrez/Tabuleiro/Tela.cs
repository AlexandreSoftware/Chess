using System;
using tabuleiro;

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
            System.Console.WriteLine("  a b c d e f g h");
        }
        public static void imprimirPeca(Peca peca){
            if(peca.cor==Cor.Branco){
                System.Console.WriteLine(peca);
            }
            else{
                    ConsoleColor aux=Console.ForegroundColor;
                    Console.ForegroundColor=ConsoleColor.Yellow;
                    System.Console.Write(peca);
                    Console.ForegroundColor=aux;
            }
        }
    }
}
