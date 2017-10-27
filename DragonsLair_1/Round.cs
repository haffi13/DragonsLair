using System;
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

        public void GetMatch(string teamName1, string teamName2)
        {
            Random ran = new Random();
            int randomWinner = ran.Next(0, 2);
            string winner;
            if(randomWinner < 1 && teamName2 != string.Empty)
            {
                winner = teamName2;   
            }
            else
            {
                winner = teamName1;
            }
            Match match = new Match();
            match.FirstOpponent = new Team(teamName1);
            match.SecondOpponent = new Team(teamName2);
            match.Winner = new Team(winner);
            AddMatch(match);
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

        public bool GetFreeRider(Team freeRiderTeam)
        {
            bool containsFreeRider;
            List<Team> freeRiderTeamList = new List<Team>();
            
            if (!freeRiderTeamList.Contains(freeRiderTeam))
            {
                freeRiderTeamList.Add(freeRiderTeam);
                containsFreeRider = false;
            }
            containsFreeRider = true;
            /*if (freeRiderTeamList == null)
            {
                containsFreeRider = false;
            }
            foreach (Team item in freeRiderTeamList)
            {
                if (freeRiderTeam == item)
                {
                    containsFreeRider = true;
                    
                }

            }
                freeRiderTeamList.Add(freeRiderTeam);
                containsFreeRider = false;
            */
            return containsFreeRider;
        }
    }
}
