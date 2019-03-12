using System;
using tabuleiro;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8,8);
            
            
            
            tab.Colocarpeca(new Torre(tab,Cor.Preto) , new Posicao(0, 0));
            tab.Colocarpeca(new Torre(tab,Cor.Branco), new Posicao(1, 3));
            tab.Colocarpeca(new Bispo(tab,Cor.Preto), new Posicao(4, 2));
            tab.Colocarpeca(new Rei(tab,Cor.Branco), new Posicao(5, 2));
            Tela.imprimirtabuleiro(tab);
            Console.ReadKey();
        }
    }
}
