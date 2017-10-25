using System.Collections.Generic;
using System.Linq;

namespace DragonsLair_1
{
    public class Round
    {
        private List<Match> matches = new List<Match>();


        
        public void AddMatch(Match m)
        {
            matches.Add(m);
        }

        public Match GetMatch(string teamName1, string teamName2)
        {
            int numOfMatches = matches.Count;
            for (int i = 0; i < numOfMatches; i++)
            {
                
            }

            // TODO: Implement this method
            return null;
        }

        public bool IsMatchesFinished()
        {
            if(matches.Count == GetWinningTeams().Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Team> GetWinningTeams()
        {
            List<Team> winningTeamList = new List<Team>();
            for (int i = 0; i < matches.Count; i++)
            {
                winningTeamList.Add(matches[i].Winner);
            }
            return winningTeamList;
        }

        public List<Team> GetLosingTeams()
        {
            List<Team> losingTeamList = new List<Team>();
            for (int i = 0; i < matches.Count; i++)
            {
                string p1 = matches[i].FirstOpponent.Name;
                string p2 = matches[i].SecondOpponent.Name;
                string win = matches[i].Winner.Name;

                if(p1 == win)
                {
                    losingTeamList.Add(matches[i].SecondOpponent);
                }
                else
                {
                    losingTeamList.Add(matches[i].FirstOpponent);
                }
            }
            return losingTeamList;
        }
    }
}
