namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            if (IsDraw())
            {
                return GetDrawScore();
            }
            return IsAnyPlayerInAdvantageOrWinningSituation() ? GetAdvantageOrWinningScore() : GetNormalScore("");
        }

        private string GetNormalScore(string score)
        {
            for (var i = 1; i < 3; i++)
            {
                int tempScore;
                if (i == 1) tempScore = m_score1;
                else
                {
                    score += "-";
                    tempScore = m_score2;
                }

                switch (tempScore)
                {
                    case 0:
                        score += "Love";
                        break;
                    case 1:
                        score += "Fifteen";
                        break;
                    case 2:
                        score += "Thirty";
                        break;
                    case 3:
                        score += "Forty";
                        break;
                }
            }

            return score;
        }

        private bool IsAnyPlayerInAdvantageOrWinningSituation()
        {
            return m_score1 >= 4 || m_score2 >= 4;
        }

        private string GetAdvantageOrWinningScore()
        {
            var score = (m_score1 - m_score2) switch
            {
                1 => "Advantage player1",
                -1 => "Advantage player2",
                >= 2 => "Win for player1",
                _ => "Win for player2"
            };
            return score;
        }

        private bool IsDraw()
        {
            return m_score1 == m_score2;
        }

        private string GetDrawScore()
        {
            var score = m_score1 switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };
            return score;
        }
    }
}

