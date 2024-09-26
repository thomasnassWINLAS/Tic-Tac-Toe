namespace TicTacToe;

public class Player
{
    public string Name { get; set; }
    char Symbol { get; set; }

    public Player(string name, char symbol)
    {
        Name = name;
        Symbol = symbol;
    }
}