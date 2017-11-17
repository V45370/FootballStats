using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbalStats.ImportExport
{
    //TODO if needed
    public class ImportService
    {
        //THIS WAS IN PROGRAM.CS 




        //CSVImporter importer = new CSVImporter(@"C:\Users\V45370\Desktop\Football CSVs\England\2016-2017\Championship.csv");
        //importer.ImportSeason("Championship","2016-2017");

        //LeagueRepository leagueRepo = new LeagueRepository();
        //var championshipLeague = leagueRepo.FindByName("Championship");
        //var thisSeason = championshipLeague.Seasons.FirstOrDefault();

        //var newcastleMatches = thisSeason.Matches.Where(x => x.AwayTeam == "Newcastle" || x.HomeTeam == "Newcastle");
        //var brightonMatches = thisSeason.Matches.Where(x => x.AwayTeam == "Brighton" || x.HomeTeam == "Brighton");

        //decimal newCastleAverageCorners = 0;
        //decimal newCastleAverageGoals = 0;
        //foreach (var match in newcastleMatches)
        //{
        //    if(match.AwayTeam == "Newcastle")
        //    {
        //        newCastleAverageCorners += match.AwayTeamCorners;
        //        newCastleAverageGoals += match.FullTimeAwayTeamGoals;
        //    }
        //    else
        //    {
        //        newCastleAverageCorners += match.HomeTeamCorners;
        //        newCastleAverageGoals += match.FullTimeHomeTeamGoals;
        //    }                
        //}

        //newCastleAverageCorners /= newcastleMatches.Count();
        //newCastleAverageGoals /= newcastleMatches.Count();

        //decimal brightonAverageCorners = 0;
        //decimal brightonAverageGoals = 0;
        //foreach (var match in brightonMatches)
        //{
        //    if (match.AwayTeam == "Brighton")
        //    {
        //        brightonAverageCorners += match.AwayTeamCorners;
        //        brightonAverageGoals += match.FullTimeAwayTeamGoals;
        //    }
        //    else
        //    {
        //        brightonAverageCorners += match.HomeTeamCorners;
        //        brightonAverageGoals += match.FullTimeHomeTeamGoals;
        //    }
        //}

        //brightonAverageCorners /= newcastleMatches.Count();
        //brightonAverageGoals /= newcastleMatches.Count();

        //Console.WriteLine("Newcastle average corners: {0}", newCastleAverageCorners);
        //Console.WriteLine("Newcastle average goals: {0}", newCastleAverageGoals);
        //Console.WriteLine("Brighton average corners: {0}", brightonAverageCorners);
        //Console.WriteLine("Brighton average goals: {0}", brightonAverageGoals);

        //Console.WriteLine("Newcastle:");
        //foreach (var match in newcastleMatches.OrderBy(x=>x.Date))
        //{
        //    if (match.AwayTeam == "Newcastle")
        //    {
        //        Console.WriteLine(match.FullTimeAwayTeamGoals);
        //    }
        //    else
        //    {
        //        Console.WriteLine(match.FullTimeHomeTeamGoals);
        //    }

        //}

        //Console.WriteLine("Brighton:");
        //foreach (var match in brightonMatches.OrderBy(x => x.Date))
        //{
        //    if (match.AwayTeam == "Brighton")
        //    {
        //        Console.WriteLine(match.FullTimeAwayTeamGoals);
        //    }
        //    else
        //    {
        //        Console.WriteLine(match.FullTimeHomeTeamGoals);
        //    }

        //}
    }
}
