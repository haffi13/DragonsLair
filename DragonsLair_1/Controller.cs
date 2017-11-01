using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonsLair_1
{
    public class Controller
    {
        private TournamentRepo tournamentRepository = new TournamentRepo();
        Round round = new Round();
        Random ran = new Random();
        List<Team> TeamScoreList = new List<Team>();

        public void ShowScore(string tournamentName)
        {
            List<Team> SortedScorelist = TeamScoreList.OrderBy(o=>o.Score).ToList();

            Console.WriteLine();
            foreach (var item in SortedScorelist)
            {
                Console.WriteLine(item.Name + "    :  " + item.Score);

            }
        }
       

        public void ScheduleNewRound(string tournamentName, bool printNewMatches = true)
        {
            Tournament tournament = new Tournament(tournamentName);
            List<Team> teamsNextRound = new List<Team>();
            
            if(round.GetWinningTeams().Count > 0)
            {
                teamsNextRound = round.GetWinningTeams();
            }
            else
            {
                TeamScoreList = tournament.GetTeams();
                teamsNextRound = tournament.GetTeams();
            }
            if(teamsNextRound.Count % 2 != 0)
            {
                Team freeRider = CheckFreeRider(teamsNextRound);
                round.GetMatch(freeRider, null);
                teamsNextRound.Remove(freeRider);
            }
            int teamsRemainingInRound = teamsNextRound.Count;
            for (int i = teamsRemainingInRound; i >=2; i-=2)
            {
                int p1 = ran.Next(0, i);
                int p2 = ran.Next(0, i);
                while (p1 == p2)
                {
                    p2 = ran.Next(0, teamsNextRound.Count);
                }
                round.GetMatch(teamsNextRound[p1], teamsNextRound[p2]);
                if (p1 > p2)
                {
                    teamsNextRound.RemoveAt(p1);
                    teamsNextRound.RemoveAt(p2);
                }
                else
                {
                    teamsNextRound.RemoveAt(p2);
                    teamsNextRound.RemoveAt(p1);
                }
               
            }
        }


        public Team CheckFreeRider(List<Team> teamsNextRound)
        {
            int freeRiderIdx;
            int numOfTeamsNextRound = teamsNextRound.Count;

            do
            {
                freeRiderIdx = ran.Next(0, numOfTeamsNextRound + 1);
            } while (round.GetFreeRider(teamsNextRound[freeRiderIdx]));
            return teamsNextRound[freeRiderIdx];


        }

        public void SaveMatch(string tournamentName, int roundNumber, string team1, string team2, string winningTeam)
        {
            // Do not implement this method
        }

        public void SetWinner()
        {
            round.SetWinnerOfEachMatch();
        }
    }
}
