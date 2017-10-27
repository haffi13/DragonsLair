using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DragonsLair_1
{
    [TestClass]
    public class DragonsLairTests
    {
        Tournament currentTournament;
        Round round = new Round();

        [TestInitialize]
        public void SetupForTest()
        {
            currentTournament = new Tournament("Vinter Turnering");
            
        }

        [TestMethod]
        public void TournamentHasEvenNumberOfTeams()
        {
            int numberOfTeams = currentTournament.GetTeams().Count;
            Assert.AreEqual(0, numberOfTeams % 2);
        }

        [TestMethod]
        public void EqualNumberOfWinnersAndLosersPerRound()
        {
            int numberOfRounds = currentTournament.GetNumberOfRounds();
            for (int round = 0; round < numberOfRounds -1; round++)
            {
                Round currentRound = currentTournament.GetRound(round);
                int numberOfWinningTeams = currentRound.GetWinningTeams().Count;
                int numberOfLosingTeams = currentRound.GetLosingTeams().Count();
                Assert.AreEqual(numberOfWinningTeams, numberOfLosingTeams);
            }
        }

        [TestMethod]
        public void OneWinnerInLastRound()
        {
            // Verifies there is exactly one winner in last round
            int numberOfRounds = currentTournament.GetNumberOfRounds();
            Round currentRound = currentTournament.GetRound(numberOfRounds - 1);
            int numberOfWinningTeams = currentRound.GetWinningTeams().Count;
            Assert.AreEqual(1, numberOfWinningTeams);
        }

        [TestMethod]
        public void AllMatchesInPreviousRoundsFinished()
        {
            bool matchesFinished = true;
            int numberOfRounds = currentTournament.GetNumberOfRounds();
            for (int round = 0; round < numberOfRounds - 1; round++)
            {
                Round currentRound = currentTournament.GetRound(round);
                if (currentRound.IsMatchesFinished() == false)
                    matchesFinished = false;
            }
            Assert.AreEqual(true, matchesFinished);
        }

        [TestMethod]
        public void FreeRiderAlwaysWins()
        {
            Round currentRound = new Round();
            currentRound.GetMatch("RandomTeamName", string.Empty);

            List<Team> winnerList = currentRound.GetWinningTeams();

            Assert.AreEqual("RandomTeamName", winnerList[0].Name);
        }

        [TestMethod]
        public void CheckIfFreeRiderIsInAList()
        {
            

          /*  List<Team> freeRiderTeamList = new List<Team>();
             new List<Team>(new Team[] {
                 new Team("The Valyrians"),
                 new Team("The Spartans"),
                 new Team("The Cretans")
             });*/

           /* List<Team> tl = new List<Team>
            {
                freeRiderTeamList[0],
                freeRiderTeamList[1],
                freeRiderTeamList[2]
            };*/

            List<Team> teamlist1 = new List<Team>();
            
            
            /*teamlist1.Add(new Team("team1"));
            teamlist1.Add(new Team("team2"));
            teamlist1.Add(new Team("team3"));*/


            round.GetFreeRider(teamlist1.ElementAt(0));
            round.GetFreeRider(teamlist1[1]);
            round.GetFreeRider(teamlist1[2]);

            Team firstitem = new Team("team1");

            /*   for (int i = 0; i < 7; i++)
               {
                   round.GetFreeRider(tl[4]);
               }*/

            Assert.AreEqual(true, round.GetFreeRider(firstitem));
            
            

        }
        


        [TestMethod]
        public void AreRandomNumbersInExpectedRange()
        {
            Controller controller = new Controller();
            
            controller.ScheduleNewRound("Vinter Turnering");

        }
    }
}