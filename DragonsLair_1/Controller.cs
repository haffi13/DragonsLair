using System;
using System.Collections.Generic;

namespace DragonsLair_1
{
    public class Controller
    {
        private TournamentRepo tournamentRepository = new TournamentRepo();
        Round round = new Round();
        Random ran = new Random();

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
                Team freeRider = CheckFreeRider(teamsNextRound);
                round.GetMatch(freeRider.Name, string.Empty);
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
                round.GetMatch(teamsNextRound[p1].Name, teamsNextRound[p2].Name);
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
