namespace tiktaktoe;

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();
        game.Start();
    }
}

class Game
{
    private char[,] board;
    private char currentPlayer;
    private bool isGameOver;

    public Game()
    {
        board = new char[3, 3];
        currentPlayer = 'X';
        isGameOver = false;
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = ' ';
            }
        }
    }

    public void Start()
    {
        while (!isGameOver)
        {
            DisplayBoard();
            PlayTurn();
            CheckForWinner();
            CheckForDraw();
            SwitchPlayer();
        }
    }

    private void DisplayBoard()
    {
        Console.WriteLine(" 1 | 2 | 3 ");
        Console.WriteLine("---|---|---");
        Console.WriteLine(" 4 | 5 | 6 ");
        Console.WriteLine("---|---|---");
        Console.WriteLine(" 7 | 8 | 9 ");

        Console.WriteLine();
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {board[0, 0]} | {board[0, 1]} | {board[0, 2]} ");
        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {board[1, 0]} | {board[1, 1]} | {board[1, 2]} ");
        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {board[2, 0]} | {board[2, 1]} | {board[2, 2]} ");
        Console.WriteLine("   |   |   ");
        Console.WriteLine();
    }

    private void PlayTurn()
    {
        bool validInput = false;
        int position = 0;

        while (!validInput)
        {
            Console.Write($"Player {currentPlayer}, enter a position (1-9): ");
            if (int.TryParse(Console.ReadLine(), out position) && position >= 1 && position <= 9)
            {
                int row = (position - 1) / 3;
                int col = (position - 1) % 3;

                if (board[row, col] == ' ')
                {
                    board[row, col] = currentPlayer;
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("That position is already taken. Try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
            }
        }
    }

    private void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
    }

    private void CheckForWinner()
    {

        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
            {
                Console.WriteLine($"Player {currentPlayer} wins!");
                isGameOver = true;
                return;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
            {
                Console.WriteLine($"Player {currentPlayer} wins!");
                isGameOver = true;
                return;
            }
        }

        if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
            (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
        {
            Console.WriteLine($"Player {currentPlayer} wins!");
            isGameOver = true;
            return;
        }
    }

    private void CheckForDraw()
    {
        bool isDraw = true;
        foreach (var cell in board)
        {
            if (cell == ' ')
            {
                isDraw = false;
                break;
            }
        }

        if (isDraw)
        {
            Console.WriteLine("It's a draw!");
            isGameOver = true;
        }
    }
}
