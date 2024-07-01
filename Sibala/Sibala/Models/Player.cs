namespace Sibala.Models;

public class Player
{
    public Player(string dice)
    {
        Dice = dice;
    }

    public string Dice { get; set; }
    public int Points { get; set; }
    public bool IsAllSameKind { get; set; }

    public void GetPoints()
    {
        Points = Dice.Distinct().Count();
    }
}