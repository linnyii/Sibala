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