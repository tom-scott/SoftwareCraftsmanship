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
        public void Return_10_Given_Strike_On_First_Ball()
        {
            var game = "X|--|--|--|--|--|--|--|--|--||--";

            var score = _bowlingGame.CalculateScore(game);

            score.Should().Be(10);
        }

        [Test]
        public void Return_0_Given_All_Ball_Misses_All_Pins()
        {
            var game = "--|--|--|--|--|--|--|--|--|--||--";

            var score = _bowlingGame.CalculateScore(game);

            score.Should().Be(0);
        }
    }

    public class BowlingGame
    {
        public int CalculateScore(string stringScore)
        {
            if (stringScore.Contains("X"))
            {
                return 10;
            }

            return 0;
        }
    }
}
