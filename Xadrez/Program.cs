using System;
using tabuleiro;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            PosicaoXadrez x = new PosicaoXadrez('a',1);             
            System.Console.WriteLine(x.ToPosicao());




        }
    }
}

