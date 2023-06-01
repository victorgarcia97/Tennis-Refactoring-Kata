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
            if (IsADraw()) return SetDrawScore("");

            if (IsDeuce()) return "Deuce";

            if (IsPlayerOneAhead()) return SetPlayerOneAheadScore();

            if (IsPlayerTwoAhead()) return SetPlayerTwoAheadScore();

            if (IsPlayerOneScoreOverPlayerTwo()) return SetNormalScoreWhenPlayerOneOverPlayerTwo();
            
            if (IsPlayerTwoScoreOverPlayerOne()) return SetNormalScoreWhenPlayerTwoOverPlayerOne();

            if (IsPlayerOneInAdvantage()) return "Advantage player1";

            if (IsPlayerTwoInAdvantage()) return "Advantage player2";

            if (PlayerOneHasWon()) return "Win for player1";
            
            if (PlayerTwoHasWon()) return "Win for player2";
            
            return "";
        }

        private string SetNormalScoreWhenPlayerTwoOverPlayerOne()
        {
            string score;
            if (p2point == 2)
                p2res = "Thirty";
            if (p2point == 3)
                p2res = "Forty";
            if (p1point == 1)
                p1res = "Fifteen";
            if (p1point == 2)
                p1res = "Thirty";
            score = p1res + "-" + p2res;
            return score;
        }

        private bool IsPlayerTwoScoreOverPlayerOne()
        {
            return p2point > p1point && p2point < 4;
        }

        private string SetNormalScoreWhenPlayerOneOverPlayerTwo()
        {
            string score;
            if (p1point == 2)
                p1res = "Thirty";
            if (p1point == 3)
                p1res = "Forty";
            if (p2point == 1)
                p2res = "Fifteen";
            if (p2point == 2)
                p2res = "Thirty";
            score = p1res + "-" + p2res;
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
            string score;
            if (p2point == 1)
                p2res = "Fifteen";
            if (p2point == 2)
                p2res = "Thirty";
            if (p2point == 3)
                p2res = "Forty";

            p1res = "Love";
            score = p1res + "-" + p2res;
            return score;
        }

        private string SetPlayerOneAheadScore()
        {
            string score;
            if (p1point == 1)
                p1res = "Fifteen";
            if (p1point == 2)
                p1res = "Thirty";
            if (p1point == 3)
                p1res = "Forty";

            p2res = "Love";
            score = p1res + "-" + p2res;
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
            if (p1point == 0)
                score = "Love";
            if (p1point == 1)
                score = "Fifteen";
            if (p1point == 2)
                score = "Thirty";
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

