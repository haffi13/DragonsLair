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
           
            Match match = new Match();
            match.FirstOpponent = new Team(teamName1);
            match.SecondOpponent = new Team(teamName2);
            
            AddMatch(match);
        }
        public void SetWinnerOfEachMatch()
        {
            
            for (int i = 0; i <= matches.Count; i++)
            {
                matches[i].Winner = SetWinner(matches[i].FirstOpponent, matches[i].SecondOpponent);
            }
            
        }
        public Team SetWinner(Team team1, Team team2)
        {
            bool findTheWinningTeam = true;
            while (findTheWinningTeam)
            {

                Console.WriteLine("Please enter the name of the winning team");

                Console.WriteLine("Team 1 is " + team1.Name +", and Team 2 is " + team2.Name );
                int winningteam = Convert.ToInt32(Console.ReadLine());
                if (winningteam == 1)
                {
                    findTheWinningTeam = false;
                    return team1;
                }
                if (winningteam == 2)
                {
                    findTheWinningTeam = false;
                    return team2;
                }
                else if ( winningteam == 0)
                {
                    findTheWinningTeam = false;
                    return null;
                }
                Console.WriteLine("Sorry, the name you entered does not match with any of the teams.");
            }
            return null;
        }
        public bool AreTeamWinnersEmpty()
        {
            
            for (int i = 0; i < matches.Count; i++)
            {
                if (matches[i].Winner.Name == null )
                { return false; }
            }
            return true;
            
        }

        public bool IsMatchesFinished()
        {
            if (matches.Count == GetWinningTeams().Count && AreTeamWinnersEmpty())
              
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
        public Team FreeRiderTeam { get; set; }
        public bool GetFreeRider(Team freeRiderTeam)
        {
            bool containsFreeRider;
           
            
            if (FreeRiderTeam == freeRiderTeam)
            {
                containsFreeRider = true;
            }
            FreeRiderTeam = freeRiderTeam;
            containsFreeRider = false;
           
            return containsFreeRider;
        }
    }
}
