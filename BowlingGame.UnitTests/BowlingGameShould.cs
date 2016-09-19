using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace BowlingGame.UnitTests
{
    [TestFixture]
    public class BowlingGameShould
    {
        private BowlingGame _bowlingGame;

        [SetUp]
        public void Setup()
        {
            _bowlingGame = new BowlingGame();
        }

        [Test]
        public void Return_Strike_When_First_Ball_Knocks_Down_All_Pins()
        {
            var game = "X|--|--|--|--|--|--|--|--|--||--";

            var score = _bowlingGame.CalculateScore(game);

            score.Should().Be(10);
        }
    }

    public class BowlingGame
    {
        public int CalculateScore(string stringScore)
        {
            return 10;
        }
    }
}
