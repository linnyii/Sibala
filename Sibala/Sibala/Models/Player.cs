namespace Sibala.Models;

public class Player
{
    public Player(string dice)
    {
        Dice = dice;
    }

    public string Dice { get; set; }
    public int Points { get; set; }
    public bool AllTheSameKind { get; set; }

    public void GetPoints()
    {
        if (Dice.Distinct().Count() == 4)
            Points = 0;
        if (Dice.Distinct().Count() == 3)
        {
            var groups = Dice.GroupBy(p => p).ToList();
            Points = groups.Where(g => g.Count() == 1).Sum(g => (int)char.GetNumericValue(g.Key));
        }

        if (Dice.Distinct().Count() == 2)
        {

            var groups = Dice.GroupBy(p => p).ToList();
            if (groups.Any(g => g.Count() == 3))
            {
                Points = 0;
            }

            if (groups.All(g => g.Count() == 2))
            {
                Points = groups.Max(g => (int)char.GetNumericValue(g.Key)) * 2;
            }
        }

        if (Dice.Distinct().Count() == 1)
        {
            Points = 999;
            AllTheSameKind = true;
        }
    }

}