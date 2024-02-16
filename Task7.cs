using System;
using System.Linq;

class queen {

    static readonly int N = 8;

    public static int a = 4;

    public static int b = 6;
    
    
//Ստուգում ենք արդյո կարող ենք թագուհին դնել այդ տեղում թե ոչ
    static bool isSafe(int[,] board, int row, int col)
    {

        //Տողի ստուգում
        for (int x = 0; x < col; x++)
            if (board[row, x] == 1)
                return false;

        //անկյունագծի ստուգում
        for (int x = row, y = col; x >= 0 && y >= 0;
             x--, y--)
            if (board[x, y] == 1)
                return false;

       //անկյունագծի ստուգում
        for (int x = row, y = col; x < N && y >= 0;
             x++, y--)
            if (board[x, y] == 1)
                return false;

        //դաշտը ազատ է
        return true;
    }


    static bool solveNQueens(int[,] board, int col)
    {
        
        //տպել տախտակը
        if (col == N) {
            for (int i = 0; i < N; i++) {
                for (int j = 0; j < N; j++) {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            return true;
        }

        
        for (int i = 0; i < N; i++) {
            
            if (isSafe(board, i, col)) {
                board[i, col] = 1; // place the queen
                if (solveNQueens(board, col + 1))
                    return true;
                board[i, col] = 0;
                
            }
        }
        return false;
    }
    
    public static void Main(string[] args)
    {
        int[,] board = new int[N, N];
        
        if (!solveNQueens(board, 0))
            Console.WriteLine("No solution found");
    }
}