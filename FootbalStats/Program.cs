using FootbalStats.Scrapers;
using Models;
using Repos;

namespace FootbalStats
{
    class Program
    {
        
        static void Main(string[] args) 
        {
            //AddInitialLeagues();

            //DO NOT RUN FIX UPDATE
            //SoccerStatsScraper soccerStatsScraper = new SoccerStatsScraper();
            //soccerStatsScraper.Scrape();

            ForebetScraper forebetScraper = new ForebetScraper();            
            forebetScraper.Scrape();

            Reporter reporter = new Reporter();

            //reporter.LeaguePercentageAnalyze(); // goal goal
            reporter.NextMatches(10); //+1 goal diff
            reporter.LeaguePercentageWithGoalDiffAnalyze(1);
            //reporter.GoalDifferenceAnalyze(1);
            //reporter.LeagiePercentageWeakTeamToNotScore(); //loti
        }

        public static void AddInitialLeagues()
        {
            string[] leagueNames = new string[] {"Premier League",
                                                 "Championship",
                                                 "Primera Division",
                                                 "Segunda Division",
                                                 "Bundesliga",
                                                 "Ligue 1",
                                                 "Serie A",
                                                 "Serie B"};
            var repo = new LeagueRepository();
            //repo.Add(new League() { Name = "Serie B" });

            foreach (var league in leagueNames)
            {
                repo.Add(new League() { Name = league });
            }
        }
    }
}
