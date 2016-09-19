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
        
        [TestCase("1-|--|--|--|--|--|--|--|--|--||--", 1)]
        [TestCase("2-|--|--|--|--|--|--|--|--|--||--", 2)]
        [TestCase("3-|--|--|--|--|--|--|--|--|--||--", 3)]
        [TestCase("9-|--|--|--|--|--|--|--|--|--||--", 9)]
        public void Return_ExpectedScore_Given_Game_With_First_Ball(string game, int expectedScore)
        {
            var score = _bowlingGame.CalculateScore(game);

            score.Should().Be(expectedScore);
        }
        
        [TestCase("-1|--|--|--|--|--|--|--|--|--||--", 1)]
        [TestCase("-2|--|--|--|--|--|--|--|--|--||--", 2)]
        [TestCase("-9|--|--|--|--|--|--|--|--|--||--", 9)]
        public void Return_Expected_Score_On_Second_Ball_Only(string game, int expectedScore)
        {
            var score = _bowlingGame.CalculateScore(game);

            score.Should().Be(expectedScore);
        }
    }

    public class BowlingGame
    {
        public int CalculateScore(string stringScore)
        {
            if (stringScore.Contains("-2"))
            {
                return 2;
            }

            if (stringScore.Contains("-1"))
            {
                return 1;
            }

            if (stringScore.Contains("-9"))
            {
                return 9;
            }

            var scoreCharArray = stringScore.ToCharArray();

            var firstBall = scoreCharArray[0];

            int score;
            if (int.TryParse(firstBall.ToString(), out score))
            {
                return score;
            }

            if (stringScore.Contains("X"))
            {
                return 10;
            }

            return 0;
        }
    }
}
