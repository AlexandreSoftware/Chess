using System;
using BoardNS.Pieces;
using BoardNS;
using System.Threading;
using System.IO;
namespace Chess {
    class Screen {
        public static void printChess(Board bor) {
            Console.Clear();
            for (int i = 0; i < bor.lines; i++) {
                System.Console.Write(8 - i + " ");
                for (int j = 0; j < bor.columns; j++) {
                    if (bor.piece(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        Screen.printPiece(bor.piece(i, j));
                        Console.Write(" ");
                    }

                }

                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void printBoard(Board bor) {
            Console.Clear();
            for (int i = 0; i < bor.lines; i++) {
                
                for (int j = 0; j < bor.columns; j++) {
                    if (bor.piece(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        printPiece(bor.piece(i, j));
                        Console.Write(" ");
                    }

                }

                Console.WriteLine();
            }
         }
         public static void possiblePosition(Board bor,bool[,] borpossivel) {
            Console.Clear();
            if(borpossivel!=null){
            for (int i = 0; i < bor.lines; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < bor.columns; j++) {
                    if (bor.piece(i, j) != null&&borpossivel[i,j]==true) {
                        ConsoleColor actualConsoleColor=Console.BackgroundColor;
                        Console.BackgroundColor=ConsoleColor.Red;
                        Screen.printPiece(bor.piece(i, j));
                        Console.Write(" ");
                        Console.BackgroundColor=actualConsoleColor;
                    }
                    else if(bor.piece(i, j) == null&&borpossivel[i,j]==true){
                        ConsoleColor actualConsoleColor=Console.BackgroundColor;
                        Console.BackgroundColor=ConsoleColor.Blue;
                        Console.Write("- ");
                        Console.BackgroundColor=actualConsoleColor;
                    }
                    else if (bor.piece(i, j) == null&&borpossivel[i,j]==false) {
                        
                        Console.Write("- ");
                    }
                    else {
                        Screen.printPiece(bor.piece(i, j));
                        Console.Write(" ");
                    }
                    
                }
                Console.WriteLine();
            }
                    Console.WriteLine("  a b c d e f g h");
            }
            else{
                throw new BoardException("There's no Matrix");
            }
            
        }
        public static void printPiece(Piece piece) {
            if (piece.color == Color.White) {
                System.Console.Write(piece);
            }
            else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
        public static ChessPosition readChessPosition() {
            string s = Console.ReadLine();
            s=s.ToLower();
            if (s == "exit") {
                Environment.Exit(0);
                return null;
            }
            if(s==""||s==null){
                throw new BoardException("Invalid input: Try again");
            }
            else {
                char coluna = s[0];
                
                bool val=int.TryParse(s[1] + "",out int linha);
                if(val==false){
                    throw new BoardException("Invalid input: Try again");
                }
                return new ChessPosition(coluna, linha);
            }
        }
        public static void printChessDelay(Board bor){
            Console.Clear();
            for (int i = 0; i < bor.lines; i++) {
                Thread.Sleep(10);
                Console.Write(8 - i + " ");
                for (int j = 0; j < bor.columns; j++) {
                    Thread.Sleep(10);
                    if (bor.piece(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        Screen.printPiece(bor.piece(i, j));
                        Console.Write(" ");
                    }

                }

                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        
    }
}