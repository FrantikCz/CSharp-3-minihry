using System;

class Program
{
    static void Main(string[] args)
    {
        char[,] board = {
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' }
        };

        char currentPlayer = 'X';

        while (true)
        {
            Console.Clear();
            PrintBoard(board);
            PlayerMove(board, currentPlayer);

            if (CheckWin(board, currentPlayer))
            {
                Console.Clear();
                PrintBoard(board);
                Console.WriteLine($" hráč {currentPlayer} VYHRÁL!");
                break;
            }

            if (IsDraw(board))
            {
                Console.Clear();
                PrintBoard(board);
                Console.WriteLine(" remíza!");
                break;
            }

            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }

        Console.WriteLine("\nKonec hry, stiskni ENTER pro ukončení...");
        Console.ReadLine();
    }

    static void PrintBoard(char[,] board)
    {
        Console.WriteLine("-------------");
        for (int i = 0; i < 3; i++)   
        {
            Console.Write("| ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j] + " | ");
            }
            Console.WriteLine();
            Console.WriteLine("-------------");
        }
    }

    static void PlayerMove(char[,] board, char player)
    {
        int row, col;
        while (true)
        {
            Console.WriteLine($"hráč {player}, je tvůj tah.");
            Console.Write("zadej řádek (1–3): ");
            row = int.Parse(Console.ReadLine()) - 1; 
            Console.Write("zadej sloupec (1–3): ");
            col = int.Parse(Console.ReadLine()) - 1;

            if (row >= 0 && row < 3 && col >= 0 && col < 3)
            {
                if (board[row, col] == ' ')
                {
                    board[row, col] = player;
                    break;
                }
                else
                {
                    Console.WriteLine(" pole je plné, zkus jiné");
                }
            }
            else
            {
                Console.WriteLine(" špatné místo, zadej čísla 1 - 3.");
            }
        }
    }

    static bool CheckWin(char[,] board, char player)
    {
        for (int i = 0; i < 3; i++)
            if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player)
                return true;

        for (int j = 0; j < 3; j++)
            if (board[0, j] == player && board[1, j] == player && board[2, j] == player)
                return true;

        if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) return true;
        if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player) return true;

        return false;
    }

    static bool IsDraw(char[,] board)
    {
        foreach (char c in board)
            if (c == ' ') return false;
        return true;
    }
}
