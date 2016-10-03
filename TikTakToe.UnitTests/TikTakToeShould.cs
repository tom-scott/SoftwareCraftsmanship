using System.Data;
using FluentAssertions;
using NUnit.Framework;

namespace TikTakToeGame.UnitTests
{
    [TestFixture]
    public class TikTakToeShould
    {
        private TikTakToe _tikTakToe;

        [SetUp]
        public void SetUp()
        {
            _tikTakToe = new TikTakToe();
        }

        [Test]
        public void Return_None_Winner_Given_No_Plays()
        {
            var winner = _tikTakToe.Winner();

            winner.Should().Be(GameResult.None);
        }
        
        [TestCase(Row.Middle, Column.Center)]
        [TestCase(Row.Top, Column.Center)]
        [TestCase(Row.Bottom, Column.Center)]
        [TestCase(Row.Middle, Column.Left)]
        [TestCase(Row.Top, Column.Left)]
        [TestCase(Row.Bottom, Column.Left)]
        [TestCase(Row.Middle, Column.Right)]
        [TestCase(Row.Top, Column.Right)]
        [TestCase(Row.Bottom, Column.Right)]
        public void Return_None_Winner_Given_X_Plays_First(Row row, Column column)
        {
            _tikTakToe.Play(row, column);

            var winner = _tikTakToe.Winner();

            winner.Should().Be(GameResult.None);
        }

        [Test]
        public void Differ_From_Non_Played_Game_Given_A_Played_Game()
        {
            var nonPlayedGame = new TikTakToe();
            var playedGame = new TikTakToe();

            playedGame.Play(Row.Top, Column.Left);
            
            nonPlayedGame.Should().NotBe(playedGame);
        }

        [Test]
        public void Equal_Given_Played_Same_Game()
        {
            var playedGame = new TikTakToe();
            var samePlayedGame = new TikTakToe();

            playedGame.Should().Be(samePlayedGame);
        }

        [Test]
        public void Play_X_When_Playing_The_First_Move_Given_Played_Game()
        {
            var game = new TikTakToe();
            game.Play(Row.Top, Column.Left);

            var symbolAtPosition = game.SymbolAt(Row.Top, Column.Left);

            symbolAtPosition.Should().Be(Symbols.X);
        }

        [Test]
        public void Play_O_When_Playing_The_Second_Move_Given_Played_Game()
        {
            var game = new TikTakToe();
            game.Play(Row.Bottom, Column.Left);
            game.Play(Row.Middle, Column.Left);

            var symbolAtPosition = game.SymbolAt(Row.Middle, Column.Left);

            symbolAtPosition.Should().Be(Symbols.O);
        }

        [Test]
        public void Play_X_When_Playing_Given_2_Moves()
        {
            var game = new TikTakToe();
            game.Play(Row.Bottom, Column.Left);
            game.Play(Row.Bottom, Column.Center);
            game.Play(Row.Middle, Column.Left);

            var symbolAtPosition = game.SymbolAt(Row.Middle, Column.Left);

            symbolAtPosition.Should().Be(Symbols.X);
        }
    }
}
