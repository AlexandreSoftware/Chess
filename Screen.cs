using System;
using BoardNS.Pieces;
using BoardNS;
using System.Threading;
using System.IO;
namespace Chess {
class Screen {
    /// <summary> 
    /// Print the Chess Board
    /// <para>Board: the chess board  
    /// </para>   
    /// </summary>
    public static void printChess(Board bor) {
        Console.Clear();
        for (int i = 0; i < bor.lines; i++) {
            System.Console.Write(8 - i + " ");
            for (int j = 0; j < bor.columns; j++) {
                printPiece(bor.piece(i,j));
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
    }
    /// <summary>
    /// Prints the Chess board, with a custom action before each print
    /// <param name="bor">The board</param>
    /// <param name="del">The Action to be performed</param>
    /// </summary>
    public static void printChessAction(Board bor,Action del){
        Console.Clear();
        for (int i = 0; i < bor.lines; i++)
        {
            System.Console.Write(8 - i + " ");
            for (int j = 0; j < bor.columns; j++)
            {
                del.Invoke();
                printPiece(bor.piece(i,j));
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
        Console.WriteLine();
    }
    /// <summary>
    /// Prints the Chess board, with a check for a delegate, if true it will print the position with a color
    /// <para>    
    /// Board: the board 
    /// del:The func to be checked, if true it will print the tile with a color
    /// color:the color to be printed, defaults to red
    /// </para>
    /// </summary>
    public static void printChessFunc(Board bor, Func<int,int,bool> del,ConsoleColor color=ConsoleColor.Red){
        Console.Clear();
        for (int i = 0; i < bor.lines; i++) 
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < bor.columns; j++)
             {
                if(del.Invoke(i,j))
                {   
                    printPiece(bor.piece(i,j),color);
                }
                else
                {
                    printPiece(bor.piece(i,j));
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
        Console.WriteLine();
    }
    private static void changeConsoleColorandWrite(ConsoleColor color,string str,ConsoleColor piececolor=ConsoleColor.White){
        ConsoleColor back= Console.BackgroundColor;
        ConsoleColor fore=Console.ForegroundColor;
        Console.BackgroundColor=color;
        Console.ForegroundColor=piececolor;
        Console.Write(str);
        Console.BackgroundColor=back;
        Console.ForegroundColor=fore;
    }
    public static void printPiece(Piece piece, ConsoleColor? color=null) {   
        string message= piece==null?"- ":piece+" ";
        if(color==null){
            ConsoleColor temp=piece!=null?
                piece.color==Color.White?ConsoleColor.White:ConsoleColor.Yellow
                    :ConsoleColor.White;
            changeConsoleColorandWrite(Console.BackgroundColor,message,temp);
        }   
        else {
            ConsoleColor temp=piece!=null?
                piece.color==Color.White?ConsoleColor.White:ConsoleColor.Yellow
                   :ConsoleColor.White;
            changeConsoleColorandWrite((ConsoleColor)color,message,temp);
        }
    }
    public static ChessPosition readChessPosition() {
            string s = Console.ReadLine();
            s=s.ToLower();
            if (s == "exit") Environment.Exit(0);
            if(s==""||s==null)throw new BoardException("Invalid input: Try again");
            else {
                char coluna = s[0];
                bool val=int.TryParse(s[1] + "",out int linha);
                if(val==false){
                    throw new BoardException("Invalid input: Try again");
                }
                return new ChessPosition(coluna, linha);
            }
        }
    }
}