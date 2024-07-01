using System.Runtime.InteropServices;
using FluentAssertions;

namespace Sibala;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void When_Two_Players_Are_No_Points_Should_Return_Draw()
    {
        var player1 = new Player("1234");
        var player2 = new Player("1234");
        var game = new Game(player1, player2);
        
        var actual = game.GetResult();
        
        actual.Should().BeEquivalentTo("Draw, No Points");
    }
}

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
        return "";
    }
}

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