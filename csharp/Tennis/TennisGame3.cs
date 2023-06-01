namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int player2Points;
        private int player1Points;
        private string player1Name;
        private string player2Name;
        public static readonly string[] POINTS_NAMES = new[] { "Love", "Fifteen", "Thirty", "Forty" };

        public TennisGame3(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            if (IsNotYetEndgame())
            {
                var score = POINTS_NAMES[player1Points];
                if (ArePlayersEqualOnPoints())
                    return score + "-All";
                else
                    return score + "-" + POINTS_NAMES[player2Points];
            }
            else
            {
                if (ArePlayersEqualOnPoints())
                    return "Deuce";
                var leader = player1Points > player2Points ? player1Name : player2Name;
                var pointsDifferenceIsOne = (player1Points - player2Points) * (player1Points - player2Points) == 1;
                if (pointsDifferenceIsOne)
                    return "Advantage " + leader;
                else
                    return "Win for " + leader;
            }
        }

        private bool ArePlayersEqualOnPoints()
        {
            return player1Points == player2Points;
        }

        private bool IsNotYetEndgame()
        {
            return (player1Points < 4 && player2Points < 4) && (player1Points + player2Points < 6);
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                this.player1Points += 1;
            else
                this.player2Points += 1;
        }

    }
}

