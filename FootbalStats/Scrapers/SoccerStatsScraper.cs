using FootbalStats.Repos;
using HtmlAgilityPack;
using Models;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbalStats.Scrapers
{
    public class SoccerStatsScraper
    {
        public List<ForebetUrl> Urls;
        public SoccerStatsScraper()
        {
            Urls = new List<ForebetUrl>();
            Urls.Add(new ForebetUrl("Premier League", "http://www.soccerstats.com/team_timing.asp?league=england&pmtype=sc10"));
            Urls.Add(new ForebetUrl("Championship", "http://www.soccerstats.com/team_timing.asp?league=england2&pmtype=sc10"));
            Urls.Add(new ForebetUrl("Primera Division", "http://www.soccerstats.com/team_timing.asp?league=spain&pmtype=sc10"));
            Urls.Add(new ForebetUrl("Segunda Division", "http://www.soccerstats.com/team_timing.asp?league=spain2&pmtype=sc10"));
            Urls.Add(new ForebetUrl("Bundesliga", "http://www.soccerstats.com/team_timing.asp?league=germany&pmtype=sc10"));
            Urls.Add(new ForebetUrl("Ligue 1", "http://www.soccerstats.com/team_timing.asp?league=france&pmtype=sc10"));
            Urls.Add(new ForebetUrl("Serie A", "http://www.soccerstats.com/team_timing.asp?league=italy&pmtype=sc10"));
            Urls.Add(new ForebetUrl("Serie B", "http://www.soccerstats.com/team_timing.asp?league=italy2&pmtype=sc10"));
        }

        public void Scrape()
        {
            ScrapingBrowser Browser = new ScrapingBrowser();
            //Browser.AllowAutoRedirect = true; // Browser has settings you can access in setup
            //Browser.AllowMetaRedirect = true;


            foreach (var url in Urls)
            {
                WebPage PageResult = Browser.NavigateToPage(url.Uri);
                HtmlNode tableContainer = PageResult.Html.CssSelect(".tabbertabdefault").FirstOrDefault();
                List<HtmlNode> rows = tableContainer.CssSelect("tr.trow2").ToList();
                rows.AddRange(tableContainer.CssSelect("tr.trow8").ToList());

                foreach (var row in rows)
                {
                    var tds = row.ChildNodes.Where(x => x.Name == "td");

                    string team = tds.ElementAt<HtmlNode>(0).InnerText.Trim();
                    string do10 = tds.ElementAt<HtmlNode>(1).InnerText;
                    string do20 = tds.ElementAt<HtmlNode>(2).InnerText;
                    string do30 = tds.ElementAt<HtmlNode>(3).InnerText;
                    string do40 = tds.ElementAt<HtmlNode>(4).InnerText;
                    string do50 = tds.ElementAt<HtmlNode>(5).InnerText;
                    string do60 = tds.ElementAt<HtmlNode>(6).InnerText;
                    string do70 = tds.ElementAt<HtmlNode>(7).InnerText;
                    string do80 = tds.ElementAt<HtmlNode>(8).InnerText;
                    string do90 = tds.ElementAt<HtmlNode>(9).InnerText;

                    SoccerStatGoalByMinute soccerStatGoalByMinute = ParseData(team, do10, do20, do30, do40, do50, do60, do70, do80, do90);
                    AddSoccerStatGoalByMinute(soccerStatGoalByMinute);
                }
            }
        }

        private SoccerStatGoalByMinute ParseData(string team, string do10, string do20, string do30, string do40, string do50, string do60, string do70, string do80, string do90)
        {
            SoccerStatGoalByMinute entity = new SoccerStatGoalByMinute();

            string removeNbsp = team.Substring(6);
            entity.Team = removeNbsp; 
            entity.Do10Scored = GetScored(do10);
            entity.Do10Conceded = GetConceded(do10);
            entity.Do20Scored = GetScored(do20);
            entity.Do20Conceded = GetConceded(do20);
            entity.Do30Scored = GetScored(do30);
            entity.Do30Conceded = GetConceded(do30);
            entity.Do40Scored = GetScored(do40);
            entity.Do40Conceded = GetConceded(do40);
            entity.Do50Scored = GetScored(do50);
            entity.Do50Conceded = GetConceded(do50);
            entity.Do60Scored = GetScored(do60);
            entity.Do60Conceded = GetConceded(do60);
            entity.Do70Scored = GetScored(do70);
            entity.Do70Conceded = GetConceded(do70);
            entity.Do80Scored = GetScored(do80);
            entity.Do80Conceded = GetConceded(do80);
            entity.Do90Scored = GetScored(do90);
            entity.Do90Conceded = GetConceded(do90);

            return entity;
        }

        private void AddSoccerStatGoalByMinute(SoccerStatGoalByMinute entity)
        {
            SoccerStatGoalByMinuteRepository repo = new SoccerStatGoalByMinuteRepository();
            repo.Add(entity);
        }

        private int GetScored(string str)
        {
            int scored = 0;

            string[] split = str.Trim().Split('-');
            scored = int.Parse(split[0].Trim());

            return scored;
        }

        private int GetConceded(string str)
        {
            int conceded = 0;

            string[] split = str.Trim().Split('-');
            conceded = int.Parse(split[1].Trim());

            return conceded;
        }
    }
}
