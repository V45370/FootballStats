using Models;
using Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbalStats
{
    public class Analyzer
    {
        MatchRepository MatchRepo;
        List<MatchResult> Matches;
        public Analyzer()
        {
            MatchRepo = new MatchRepository();
            Matches = MatchRepo.List.ToList();
        }

        public Tuple<double, int, int> WeakTeamToScore(int goalDiff)
        {
            double percentage = 0;
            int totalClalified = 0;
            int correctlyClalified = 0;
            DateTime today = DateTime.Now;

            var finishedMatches = Matches.Where(m => m.Date < today);
            var predictedBothToScore = finishedMatches.Where(m => m.ExactScore1 != 0 && m.ExactScore2 != 0 && Math.Abs(m.ExactScore1 - m.ExactScore2) >= goalDiff);
            List<MatchResult> weakTeamScored = predictedBothToScore.Where(m => m.ExactScore1 < m.ExactScore2 && m.Team1Goals != 0).ToList();
            weakTeamScored.AddRange(predictedBothToScore.Where(m => m.ExactScore2 < m.ExactScore1 && m.Team2Goals != 0).ToList());

            double predictedBothToScoreCount = Convert.ToDouble(predictedBothToScore.Count());
            double actuallyWeakTeamScoredCount = Convert.ToDouble(weakTeamScored.Count());
            percentage = actuallyWeakTeamScoredCount / predictedBothToScoreCount;
            totalClalified = Convert.ToInt32(predictedBothToScoreCount);
            correctlyClalified = Convert.ToInt32(actuallyWeakTeamScoredCount);

            return new Tuple<double, int, int>(percentage, totalClalified, correctlyClalified);
        }

        public double WeakTeamToScoreByLeague(string leagueName)
        {
            LeagueRepository leagueRepo = new LeagueRepository();
            League league = new League();
            league = leagueRepo.FindByName(leagueName);
            double percentage = 0;
            DateTime today = DateTime.Now;

            var finishedMatches = league.Matches.Where(m => m.Date < today);
            var predictedBothToScore = finishedMatches.Where(m => m.ExactScore1 != 0 && m.ExactScore2 != 0);
            
            List<MatchResult> weakTeamScored = predictedBothToScore.Where(m => m.ExactScore1 < m.ExactScore2 && m.Team1Goals != 0).ToList();
            weakTeamScored.AddRange(predictedBothToScore.Where(m => m.ExactScore2 < m.ExactScore1 && m.Team2Goals != 0).ToList());

            double predictedBothToScoreCount = Convert.ToDouble(predictedBothToScore.Count());
            double actuallyWeakTeamScoredCount = Convert.ToDouble(weakTeamScored.Count());
            percentage = actuallyWeakTeamScoredCount / predictedBothToScoreCount;

            return percentage;
        }

        public Tuple<double, int, int> WeakTeamToScoreWithGoalDifferenceByLeague(int goalDiff, string leagueName)
        {
            double percentage = 0;
            int totalClalified = 0;
            int correctlyClalified = 0;

            LeagueRepository leagueRepo = new LeagueRepository();
            League league = new League();
            league = leagueRepo.FindByName(leagueName);
            
            DateTime today = DateTime.Now;

            var finishedMatches = league.Matches.Where(m => m.Date < today);
            var predictedBothToScore = finishedMatches.Where(m => m.ExactScore1 != 0 
                                                                    && m.ExactScore2 != 0 
                                                                    && Math.Abs(m.ExactScore1 - m.ExactScore2) >= goalDiff);

            List<MatchResult> weakTeamScored = predictedBothToScore.Where(m => m.ExactScore1 < m.ExactScore2 
                                                                                && m.Team1Goals != 0).ToList();
            weakTeamScored.AddRange(predictedBothToScore.Where(m => m.ExactScore2 < m.ExactScore1 
                                                                    && m.Team2Goals != 0).ToList());

            double predictedBothToScoreCount = Convert.ToDouble(predictedBothToScore.Count());
            double actuallyWeakTeamScoredCount = Convert.ToDouble(weakTeamScored.Count());
            percentage = actuallyWeakTeamScoredCount / predictedBothToScoreCount;
            totalClalified = predictedBothToScore.Count();
            correctlyClalified = weakTeamScored.Count();

            return new Tuple<double, int, int>(percentage, totalClalified, correctlyClalified);
        }

        public Tuple<double, int, int> WeakTeamToScoreByLeagueClean(string leagueName)
        {
            double percentage = 0;
            int successCount = 0;
            int failCount = 0;
            int total = 0;

            LeagueRepository leagueRepo = new LeagueRepository();
            League league = new League();
            league = leagueRepo.FindByName(leagueName);
            DateTime today = DateTime.Today;

            //weak team to score success
            //weak team 0 fail
            //success / (fail + success)
            var finishedMatches = league.Matches.Where(m => m.Date < today);
            var success = finishedMatches.Where(m => (m.Percentage1 < m.Percentage2 && m.Team1Goals != 0)
                                                    || (m.Percentage2 < m.Percentage1 && m.Team2Goals != 0));
            var fail = finishedMatches.Where(m => (m.Percentage1 < m.Percentage2 && m.Team1Goals == 0)
                                                || (m.Percentage2 < m.Percentage1 && m.Team2Goals == 0));
                        
            successCount = success.Count();
            failCount = fail.Count();
            total = successCount + failCount;
            percentage = Convert.ToDouble(successCount) / Convert.ToDouble(total);

            return new Tuple<double, int, int>(percentage, successCount, total);
        }
    }
}
