int row = 7;
int col = 7;
int[,] chessboard = new int[8, 8];
int flag = 0;
Console.ForegroundColor = ConsoleColor.White;

//Տպում ենք շախմատի տախտակը
void visual(){
    for (int i = 0; i < 8; i++)
    {
        for (int j = 0; j < 8; j++)
        {
            if (chessboard[i, j] == 9)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Q ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (chessboard[i, j] == 1)
            {
                Console.Write("1 ");
            }
            else
            {
                Console.Write("0 ");
            }
        }
        Console.WriteLine();
    }
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
}

//Ավելացնել նոր թագուհի։
int AddQueen(int row, int col)
{
    int c = 0;
    for (int i = 0; i < 8; i++)
    {
        for (int j = 0; j < 8; j++)
        {
            if (row == i && col == j)
            {
                chessboard[i, j] = 9;
            }
            else if (chessboard[i, j] == 1 || chessboard[i, j] == 9)
            {
                continue;
            }
            else if ((Math.Abs(row - i) == Math.Abs(col - j)) || row == i || col == j)
            {
                chessboard[i, j] = 1;
            }
            else
            {
                c++;
            }
        }
    }
    return c;
}

int CheckPosition(int row, int col)
{
    int cc = 0;
    for (int i = 0; i < 8; i++)
    {
        for (int j = 0; j < 8; j++)
        {
            if (row == i && col == j)
            {
                continue;
            }
            else if ((Math.Abs(row - i) == Math.Abs(col - j)) || row == i || col == j)
            {
                if (chessboard[i, j] == 0)
                {
                    cc++;
                }
            }
        }
    }
    return cc;
}

while(flag == 0)
{
    int c = AddQueen(row, col);
    visual();
   
    if (c != 0)
    {
        row = -1;
        col = -1;
        int minc = 100;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (chessboard[i, j] != 1 && chessboard[i, j] != 9)
                {
                    int currentConflicts = CheckPosition(i, j);
                    if (currentConflicts <= minc)
                    {
                        minc = currentConflicts;
                        row = i;
                        col = j;
                    }
                }
            }
        }
    }
    else
    {
        Console.WriteLine("No valid position for placing the queen.");
        flag = 1;
        break;
    }
}
