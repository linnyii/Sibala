namespace Sibala.Models;

public class Game()
{ 
    public Player Player1 { get; set; } = null!;
    public Player Player2 { get; set; } = null!;
    public string? Result { get; set; }
    public Game(Player player1, Player player2) : this()
    {
        Player1 = player1;
        Player2 = player2;
    }

    public string GetResult()
    {
        Player1.GetPoints();
        Player2.GetPoints();
        if (Player1.Points == Player2.Points)
        {
            return "Draw, No Points";
        }
        
        if (Player1.AllTheSameKind)
        {
            return "Player1 Win, All The Same Kind";
        }
        
        if (Player2.AllTheSameKind)
        {
            return "Player2 Win, All The Same Kind";
        }
        
        return "";
    }
}