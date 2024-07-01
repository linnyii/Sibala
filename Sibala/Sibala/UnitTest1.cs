using System.Runtime.InteropServices;
using FluentAssertions;
using Sibala.Models;

namespace Sibala;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("1234", "1234", "Draw, No Points")]
    [TestCase("1114", "1115", "Draw, No Points")]
    public void When_Two_Players_Are_No_Points_Should_Return_Draw(string player1Dice, string player2Dice, string expected)
    {
        var player1 = new Player(player1Dice);
        var player2 = new Player(player2Dice);
        var game = new Game(player1, player2);
        
        var actual = game.GetResult();
        
        actual.Should().BeEquivalentTo("Draw, No Points");
        
    }
}