using System;
using tabuleiro;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab =new Tabuleiro(8,8);
            tab.Colocarpeca(new Rei(tab,Cor.Laranja),new Posicao(1,2));
            tab.Colocarpeca(new Torre(tab,Cor.Laranja),new Posicao(1,4));
            tab.Colocarpeca(new Bispo(tab,Cor.Laranja),new Posicao(1,3));
            tab.Colocarpeca(new Torre(tab,Cor.Laranja),new Posicao(1,5));
            Tela.imprimirtabuleiro(tab);
            Console.ReadKey();


        }
    }
}

