using FootbalStats.Algorithms;
using FootbalStats.Repos;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbalStats
{
    public class Reporter
    {
        private Analyzer analyzer;
        private Advisor advisor;
        private string[] leagueNames = new string[] {"Premier League",
                                                 "Championship",
                                                 "Primera Division",
                                                 "Segunda Division",
                                                 "Bundesliga",
                                                 "Ligue 1",
                                                 "Serie A",
                                                 "Serie B"
                                                            };
        public Reporter()
        {
            analyzer = new Analyzer();
            advisor = new Advisor();
        }

        public void Report()
        {
            //LeaguePercentageAnalyze();

            //NextMatches(10);
            //LeaguePercentageWithGoalDiffAnalyze(1);
            //GoalDifferenceAnalyze(0);
        }

        #region Percentages

        //Loti 
        public void LeagiePercentageWeakTeamToNotScore()
        {
            Console.WriteLine("Loti by league percentage: ");
            foreach (var league in leagueNames)
            {
                Tuple<double, int, int> result = analyzer.WeakTeamToScoreByLeagueClean(league);
                Console.WriteLine(league + " (" + result.Item2.ToString() + "/" + result.Item3.ToString() + ") " + (Math.Round(result.Item1, 2) * 100).ToString() + "%");
            }
        }

        //Before NOW GOAL GOAL
        public void LeaguePercentageAnalyze()
        {
            Console.WriteLine("Weak team to score by league percentage: ");
            foreach (var league in leagueNames)
            {
                double percentage = analyzer.WeakTeamToScoreByLeague(league);
                Console.WriteLine(league + " " + (Math.Round(percentage, 2) * 100).ToString() + "%");
            }
        }

        //Before NOW
        public void LeaguePercentageWithGoalDiffAnalyze(int goalDiff)
        {

            Console.WriteLine("Weak team to score by league percentage with goal difference({0}): ", goalDiff);
            foreach (var league in leagueNames)
            {
                Tuple<double, int, int> result = analyzer.WeakTeamToScoreWithGoalDifferenceByLeague(goalDiff, league);
                Console.WriteLine(league + " (" + result.Item2.ToString() + "/" + result.Item3.ToString() + ") " + (Math.Round(result.Item1, 2) * 100).ToString() + "%");
            }
        }

        //Before NOW
        public void GoalDifferenceAnalyze(int goalDiff)
        {

            Console.WriteLine("Weak team to score percentage with goal difference({0}): ", goalDiff);
            Tuple<double, int, int> result = analyzer.WeakTeamToScore(goalDiff);
            Console.WriteLine(" (" + result.Item2.ToString() + "/" + result.Item3.ToString() + ") " + (Math.Round(result.Item1, 2) * 100).ToString() + "%");
        }
        #endregion

        #region Prints
        //prints next matches today + days
        public void NextMatches(int days)
        {
            Console.WriteLine("Weak team to score by league for the next {0} days: ", days);
            foreach (var league in leagueNames)
            {
                List<MatchResult> leagueMatches = advisor.WeakTeamToScoreByLeagueToday(league, days).OrderBy(x => x.Date).ToList(); //+1 goal diff

                foreach (var leagueMatch in leagueMatches)
                {
                    Console.WriteLine(leagueMatch.ToString());
                    Console.WriteLine(FindCorrespondingSoccerStatsMatch(leagueMatch).ToString());
                }

            }
        }
        #endregion

        private SoccerStatGoalByMinute FindCorrespondingSoccerStatsMatch(MatchResult match)
        {
            SoccerStatGoalByMinute result = new SoccerStatGoalByMinute();
            SoccerStatGoalByMinuteRepository repo = new SoccerStatGoalByMinuteRepository();

            List<SoccerStatGoalByMinute> soccerStats = repo.List.ToList();

            foreach (var soccerStat in soccerStats)
            {
                double distance = 0;
                if (match.ExactScore1 < match.ExactScore2)
                {
                    distance = LevenshteinDistance.Compute(soccerStat.Team, match.Team1);
                }
                else if (match.ExactScore2 < match.ExactScore1)
                {
                    distance = LevenshteinDistance.Compute(soccerStat.Team, match.Team2);
                }

                if (distance < 5)
                {
                    result = soccerStat;
                }
            }


            return result;
        }





    }
}
