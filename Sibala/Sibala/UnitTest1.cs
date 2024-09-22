using FluentAssertions;
using Sibala.Models;

namespace Sibala;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }
    
    [TestCase("1111")]
    [TestCase("2222")]
    [TestCase("3333")]
    public void Player_With_All_The_Same_Kind(string playerDice)
    {
        var player = new Player(playerDice);
        
        player.GetPoints();

        player.Points.Should().Be(999);
    }
    
    [TestCase("1234")]
    [TestCase("1235")]
    [TestCase("3222")]
    [TestCase("3331")]
    public void Player_With_No_Points(string playerDice)
    {
        var player = new Player(playerDice);
        
        player.GetPoints();

        player.Points.Should().Be(0);
    }

    [TestCase ("2234", 7)]
    [TestCase ("4435", 8)]
    [TestCase ("1266", 3)]
    public void Player_With_One_Pair(string playerDice, int expectedPoints)
    {
        var player = new Player(playerDice);
        
        player.GetPoints();

        player.Points.Should().Be(expectedPoints);
    }
    
    [TestCase ("2233", 6)]
    [TestCase ("4455", 10)]
    [TestCase ("1116", 0)]
    public void Player_With_Two_Pair(string playerDice, int expectedPoints)
    {
        var player = new Player(playerDice);
        
        player.GetPoints();

        player.Points.Should().Be(expectedPoints);
    }

    [TestCase("1234", "1234", "Draw, No Points")]
    [TestCase("1114", "1115", "Draw, No Points")]
    [TestCase("1111", "2222", "Draw, No Points")]
    public void When_Two_Players_Are_No_Points_Should_Return_Draw_No_Points(string player1Dice, string player2Dice, string expected)
    {
        var player1 = new Player(player1Dice);
        var player2 = new Player(player2Dice);
        var game = new Game(player1, player2);
        
        var actual = game.GetResult();
        
        actual.Should().BeEquivalentTo("Draw, No Points");
        
    }
    
    [TestCase("1111", "1234", "Player1 Win, All The Same Kind")]
    [TestCase("1234", "1111", "Player2 Win, All The Same Kind")]
    public void When_Player_Win_By_All_The_Same_Kind(string player1Dice, string player2Dice, string expected)
    {
        var player1 = new Player(player1Dice);
        var player2 = new Player(player2Dice);
        var game = new Game(player1, player2);
        
        var actual = game.GetResult();
        
        actual.Should().BeEquivalentTo(expected);
    }
    
    [TestCase("3331", "2233", "Player1 Win, One Pair, Points: 6")]
    [TestCase("1233", "4456", "Player2 Win, One Pair, Points: 11")]
    [TestCase("3344", "5566", "Player2 Win, One Pair, Points: 12")]
    public void When_Player_Win_By_One_Pair(string player1Dice, string player2Dice, string expected)
    {
        var player1 = new Player(player1Dice);
        var player2 = new Player(player2Dice);
        var game = new Game(player1, player2);
        
        var actual = game.GetResult();
        
        actual.Should().BeEquivalentTo(expected);
    }

    
    
    
    
    
}
