using System;
using System.Collections.Generic;

namespace DragonsLair_1
{
    public class Controller
    {
        private TournamentRepo tournamentRepository = new TournamentRepo();
        Round round = new Round();
              

        public void ShowScore(string tournamentName)
        {
            /*Tournament tournament = tournamentRepository.GetTournament(tournamentName);
            int numOfRounds = tournament.GetNumberOfRounds();
            for (int i = 0; i < numOfRounds; i++)
            {
                //tournament.GetRound(i);


            }
            /*
             * TODO: Calculate for each team how many times they have won
             * Sort based on number of matches won (descending)
             */
            Console.WriteLine("Implement this method!");
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
                teamsNextRound = tournament.GetTeams();
            }
            if(teamsNextRound.Count % 2 != 0)
            {
                //if odd bump one team
            }
            int teamsRemainingInRound = teamsNextRound.Count;
            for (int i = teamsRemainingInRound; i > 0; i-=2)
            {
                Random ran = new Random();
                int p1 = ran.Next(0, i+1);
                int p2 = ran.Next(0, i+1);
                while (p1 == p2)
                {
                    p2 = ran.Next(0, teamsNextRound.Count);
                }
                round.GetMatch(teamsNextRound[p1].Name, teamsNextRound[p2].Name);
                teamsNextRound.RemoveAt(p1);
                teamsNextRound.RemoveAt(p2);
            }

        }

        public void SaveMatch(string tournamentName, int roundNumber, string team1, string team2, string winningTeam)
        {
            // Do not implement this method
        }
    }
}
