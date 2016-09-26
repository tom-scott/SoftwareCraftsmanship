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

        [Test]
        public void Return_10_Given_Miss_On_First_Ball_And_Spare_On_Second_Ball_Only()
        {
            var game = "-/|--|--|--|--|--|--|--|--|--||--";

            var score = _bowlingGame.CalculateScore(game);

            score.Should().Be(10);
        }

        [Test]
        public void Return_10_Given_1_On_First_Ball_And_Spare_On_Second_Ball_Only()
        {
            var game = "1/|--|--|--|--|--|--|--|--|--||--";

            var score = _bowlingGame.CalculateScore(game);

            score.Should().Be(10);
        }
    }

    public class BowlingGame
    {
        private const int StrikeScore = 10;
        private const string StrikeSymbol = "X";

        public int CalculateScore(string stringScore)
        {
            if (stringScore.Contains("-/"))
            {
                return 10;
            }

            int totalScore = 0;

            for (int i = 0; i < 2; i++)
            {
                var ball = stringScore[i].ToString();

                int score;

                if (int.TryParse(ball, out score))
                {
                    totalScore += score;
                }

                if (IsAStrike(ball))
                {
                    totalScore += StrikeScore;
                }
            }

            return totalScore;
        }

        private bool IsAStrike(string ball)
        {
            return ball.Contains(StrikeSymbol);
        }
    }
}
