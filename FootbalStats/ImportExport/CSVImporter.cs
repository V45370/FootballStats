using Microsoft.VisualBasic.FileIO;
using Models;
using Repos;
using System;
using System.Collections.Generic;

namespace FootbalStats.ImportExport
{
    //public class CSVImporter
    //{
    //    private TextFieldParser parser;

    //    public CSVImporter(string filePath)
    //    {
    //        parser = new TextFieldParser(filePath);
    //    }

    //    public void ImportSeason(string leagueName, string seasonName)
    //    {
    //        List<MatchResult> matches = new List<MatchResult>();
    //        using (parser)
    //        {
    //            parser.TextFieldType = FieldType.Delimited;
    //            parser.SetDelimiters(",");
                
    //            MatchResult match = new MatchResult();
    //            while (!parser.EndOfData)
    //            {
    //                string[] fields = parser.ReadFields();
    //                if (fields[1] != "Date")
    //                {
    //                    match = new MatchResult();
    //                    match.Date = DateTime.Parse(fields[1]);
    //                    match.HomeTeam = fields[2];
    //                    match.AwayTeam = fields[3];
    //                    if (!string.IsNullOrEmpty(fields[17])) match.HomeTeamCorners = Decimal.Parse(fields[17]);
    //                    if (!string.IsNullOrEmpty(fields[18])) match.AwayTeamCorners = Decimal.Parse(fields[18]);
    //                    if (!string.IsNullOrEmpty(fields[5])) match.FullTimeAwayTeamGoals = Decimal.Parse(fields[5]);
    //                    if (!string.IsNullOrEmpty(fields[4])) match.FullTimeHomeTeamGoals = Decimal.Parse(fields[4]);
                        
    //                    matches.Add(match);
    //                }

    //            }
    //        }
    //        Season season = new Season();
    //        season.Name = seasonName;
    //        season.Matches = matches;

    //        LeagueRepository leagueRepo = new LeagueRepository();
    //        League league = leagueRepo.FindByName(leagueName);
    //        if (league != null)
    //        {
    //            league.Seasons.Add(season);
    //            leagueRepo.Update(league);
    //        }
    //        else
    //        {
    //            league = new League();
    //            league.Name = leagueName;
    //            league.Seasons.Add(season);
    //            leagueRepo.Add(league);
    //        }                        
    //    }
    //}
}
