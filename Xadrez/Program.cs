using System;
using BoardNS;
namespace Chess
{
     class Program
    {
        static void Main(string[] args)
        {
            
            ChessGame jogo = new ChessGame();
            jogo.GameLoop();
            

        }
    }
}

