namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        private string p1res = "";
        private string p2res = "";
        private string player1Name;
        private string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            p1point = 0;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            var score = "";

            if (IsADraw())
            {
                score = SetDrawScore(score);
            }

            if (IsDeuce())
            {
                score = "Deuce";
            }

            if (IsPlayerOneAhead())
            {
                score = SetPlayerOneAheadScore();
            }

            if (IsPlayerTwoAhead())
            {
                score = SetPlayerTwoAheadScore();
            }

            if (IsPlayerOneScoreOverPlayerTwo())
            {
                score = SetNormalScoreWhenPlayerOneOverPlayerTwo();
            }

            if (IsPlayerTwoScoreOverPlayerOne())
            {
                score = SetNormalScoreWhenPlayerTwoOverPlayerOne();
            }

            if (IsPlayerOneInAdvantage())
            {
                score = "Advantage player1";
            }

            if (IsPlayerTwoInAdvantage())
            {
                score = "Advantage player2";
            }

            if (PlayerOneHasWon())
            {
                score = "Win for player1";
            }

            if (PlayerTwoHasWon())
            {
                score = "Win for player2";
            }
            
            return score;
        }

        private string SetNormalScoreWhenPlayerTwoOverPlayerOne()
        {
            p2res = p2point switch
            {
                2 => "Thirty",
                3 => "Forty",
                _ => p2res
            };
            p1res = p1point switch
            {
                1 => "Fifteen",
                2 => "Thirty",
                _ => p1res
            };
            var score = p1res + "-" + p2res;
            return score;
        }

        private bool IsPlayerTwoScoreOverPlayerOne()
        {
            return p2point > p1point && p2point < 4;
        }

        private string SetNormalScoreWhenPlayerOneOverPlayerTwo()
        {
            p1res = p1point switch
            {
                2 => "Thirty",
                3 => "Forty",
                _ => p1res
            };
            p2res = p2point switch
            {
                1 => "Fifteen",
                2 => "Thirty",
                _ => p2res
            };
            var score = p1res + "-" + p2res;
            return score;
        }

        private bool IsPlayerOneScoreOverPlayerTwo()
        {
            return p1point > p2point && p1point < 4;
        }

        private bool PlayerTwoHasWon()
        {
            return p2point >= 4 && p1point >= 0 && (p2point - p1point) >= 2;
        }

        private bool PlayerOneHasWon()
        {
            return p1point >= 4 && p2point >= 0 && (p1point - p2point) >= 2;
        }

        private bool IsPlayerTwoInAdvantage()
        {
            return p2point > p1point && p1point >= 3;
        }

        private bool IsPlayerOneInAdvantage()
        {
            return p1point > p2point && p2point >= 3;
        }

        private string SetPlayerTwoAheadScore()
        {
            p2res = p2point switch
            {
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => p2res
            };

            p1res = "Love";
            var score = p1res + "-" + p2res;
            return score;
        }

        private string SetPlayerOneAheadScore()
        {
            p1res = p1point switch
            {
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => p1res
            };

            p2res = "Love";
            var score = p1res + "-" + p2res;
            return score;
        }

        private bool IsPlayerTwoAhead()
        {
            return p2point > 0 && p1point == 0;
        }

        private bool IsPlayerOneAhead()
        {
            return p1point > 0 && p2point == 0;
        }

        private bool IsDeuce()
        {
            return p1point == p2point && p1point > 2;
        }

        private string SetDrawScore(string score)
        {
            score = p1point switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                _ => score
            };
            score += "-All";
            return score;
        }

        private bool IsADraw()
        {
            return p1point == p2point && p1point < 3;
        }

        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                P2Score();
            }
        }

        private void P1Score()
        {
            p1point++;
        }

        private void P2Score()
        {
            p2point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }
}

