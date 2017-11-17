using Models;
using Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbalStats
{
    public class Advisor
    {
        public Advisor()
        {

        }
        public List<MatchResult> WeakTeamToScoreByLeagueToday(string leagueName, int days)
        {
            LeagueRepository leagueRepo = new LeagueRepository();
            League league = new League();
            league = leagueRepo.FindByName(leagueName);
            DateTime today = DateTime.Today;

            var finishedMatches = league.Matches.Where(m => m.Date >= today
                                                            && m.Date <= today.AddDays(days)
                                                        ).OrderBy(m => m.Date);
            var predictedBothToScore = finishedMatches.Where(m => m.ExactScore1 != 0
                                                                  && m.ExactScore2 != 0);
            List<MatchResult> weakTeamScored = predictedBothToScore.Where(m => m.ExactScore1 < m.ExactScore2).ToList();
            weakTeamScored.AddRange(predictedBothToScore.Where(m => m.ExactScore2 < m.ExactScore1).ToList());

            return weakTeamScored;
        }
    }
}
