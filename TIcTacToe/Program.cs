namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var playerX = new Player("Player X", 'X');
            var playerO = new Player("Player O", 'O');
            var game = new TicTacToeGame(playerX, playerO);
            var random = new Random();

            while (true)
            {
                Console.Clear();
                game.PrintBoard();

                Console.WriteLine($"{game.CurrentPlayer.Name}'s turn ({game.CurrentPlayer.Symbol}).");

                int row, col;
                do
                {
                    row = random.Next(0, 3);
                    col = random.Next(0, 3);
                } while (!game.MakeMove(row, col));

                if (game.CheckWin())
                {
                    Console.Clear();
                    game.PrintBoard();
                    Console.WriteLine($"{game.CurrentPlayer.Name} wins!");
                    break;
                }

                if (game.CheckDraw())
                {
                    Console.Clear();
                    game.PrintBoard();
                    Console.WriteLine("The game is a draw!");
                    break;
                }

                System.Threading.Thread.Sleep(500);
            }
        }
    }
}