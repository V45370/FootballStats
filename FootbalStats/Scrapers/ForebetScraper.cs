using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using Models;
using Repos;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FootbalStats.Scrapers
{
    public class ForebetScraper
    {
        public List<ForebetUrl> Urls;
        public ForebetScraper()
        {
            Urls = new List<ForebetUrl>();
            Urls.Add(new ForebetUrl("Premier League", "https://www.forebet.com/en/football-tips-and-predictions-for-england/premier-league"));
            Urls.Add(new ForebetUrl("Championship", "https://www.forebet.com/en/football-tips-and-predictions-for-england/championship"));
            Urls.Add(new ForebetUrl("Primera Division", "https://www.forebet.com/en/football-tips-and-predictions-for-spain/primera-division"));
            Urls.Add(new ForebetUrl("Segunda Division", "https://www.forebet.com/en/football-tips-and-predictions-for-spain/segunda-division"));
            Urls.Add(new ForebetUrl("Bundesliga", "https://www.forebet.com/en/football-tips-and-predictions-for-germany/Bundesliga"));
            Urls.Add(new ForebetUrl("Ligue 1", "https://www.forebet.com/en/football-tips-and-predictions-for-france/ligue1"));
            Urls.Add(new ForebetUrl("Serie A", "https://www.forebet.com/en/football-tips-and-predictions-for-italy/serie-a"));
            Urls.Add(new ForebetUrl("Serie B", "https://www.forebet.com/en/football-tips-and-predictions-for-italy/serie-b"));            
        }

        public void Scrape()
        {
            ScrapingBrowser Browser = new ScrapingBrowser();
            //Browser.AllowAutoRedirect = true; // Browser has settings you can access in setup
            //Browser.AllowMetaRedirect = true;


            foreach (var url in Urls)
            {
                WebPage PageResult = Browser.NavigateToPage(url.Uri);
                List<HtmlNode> rows = PageResult.Html.CssSelect(".tr_0").ToList();
                rows.AddRange(PageResult.Html.CssSelect(".tr_1").ToList());

                foreach (var row in rows)
                {
                    var tds = row.ChildNodes.Where(x => x.Name == "td");

                    //TEAMS
                    string teams = string.Empty;
                    try
                    {
                        teams = tds.ElementAt<HtmlNode>(0).ChildNodes.Where(x => x.Name == "a").FirstOrDefault().InnerHtml;
                    }
                    catch (Exception ex)
                    {

                    }
                    //string teams = row.CssSelect(".tnms a").FirstOrDefault().InnerHtml;

                    //DATE
                    string date = string.Empty;
                    try
                    {
                        date = tds.ElementAt<HtmlNode>(0).ChildNodes.Where(x => x.Name == "span").FirstOrDefault().InnerText;
                    }
                    catch (Exception ex)
                    {

                    }
                    //string date = row.CssSelect(".tnms .date_bah").FirstOrDefault()?.InnerText;

                    //PERCENTAGE 1
                    string percentage1 = string.Empty;
                    try
                    {
                        percentage1 = tds.ElementAt<HtmlNode>(1)?.InnerText;
                    }
                    catch (Exception ex)
                    {

                    }

                    //PERCENTAGE X
                    string percentageX = string.Empty;
                    try
                    {
                        percentageX = tds.ElementAt<HtmlNode>(2)?.InnerText;
                    }
                    catch (Exception ex)
                    {

                    }

                    //PERCENTAGE 2
                    string percentage2 = string.Empty;
                    try
                    {
                        percentage2 = tds.ElementAt<HtmlNode>(3)?.InnerText;
                    }
                    catch (Exception ex)
                    {

                    }

                    //PREDICTION
                    string prediction = string.Empty;
                    try
                    {
                        prediction = tds.ElementAt<HtmlNode>(4)?.InnerText;
                    }
                    catch (Exception ex)
                    {

                    }
                    //string prediction = row.CssSelect(".predict").FirstOrDefault()?.InnerText;
                    //if (string.IsNullOrEmpty(prediction)) prediction = row.CssSelect(".predict_y").FirstOrDefault()?.InnerText;
                    //if (string.IsNullOrEmpty(prediction)) prediction = row.CssSelect(".predict_no").FirstOrDefault()?.InnerText;

                    //EXACT SCORE
                    string exactScore = string.Empty;
                    try
                    {
                        exactScore = tds.ElementAt<HtmlNode>(5)?.InnerText;
                    }
                    catch (Exception ex)
                    {

                    }
                    //string exactScore = row.CssSelect(".scrpred").FirstOrDefault()?.InnerText;

                    //AVERAGE SCORE
                    string averageScore = string.Empty;
                    try
                    {
                        averageScore = tds.ElementAt<HtmlNode>(6)?.InnerText;
                    }
                    catch (Exception ex)
                    {

                    }

                    //TODO return commented code if needed
                    //string finalScore = row.CssSelect(".lscr_td").FirstOrDefault()?.InnerText;

                    string finalScore = string.Empty;
                    try
                    {
                        if (tds.Count() == 12)
                        {
                            finalScore = tds.ElementAt<HtmlNode>(11)?.InnerText;
                        }
                    }
                    catch (Exception ex)
                    {

                    }


                    MatchResult match = ParseData(teams, date, percentage1, percentageX, percentage2, prediction, exactScore, averageScore, finalScore);
                    AddOrUpdateMatch(match, url.League);
                }
            }
        }

        public MatchResult ParseData(string teams, string date, string percentage1, string percentageX, string percentage2, string prediction, string exactScore, string averageScore, string finalScore)
        {
            MatchResult match = new MatchResult();
            match.Date = DateTime.ParseExact(date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture).AddHours(3);

            int percentage_1 = int.TryParse(percentage1, out percentage_1) ? percentage_1 : 0;
            match.Percentage1 = percentage_1;
            int percentage_X = int.TryParse(percentageX, out percentage_X) ? percentage_X : 0;
            match.PercentageX = percentage_X;
            int percentage_2 = int.TryParse(percentage2, out percentage_2) ? percentage_2 : 0;
            match.Percentage2 = percentage_2;
            match.Prediction = prediction;

            int exactScore_1 = 0;
            int exactScore_2 = 0;
            if (!string.IsNullOrEmpty(exactScore))
            {
                string[] exactResultPred = exactScore.Split('-');
                int.TryParse(exactResultPred[0], out exactScore_1);
                int.TryParse(exactResultPred[1], out exactScore_2);
                match.ExactScore1 = exactScore_1;
                match.ExactScore2 = exactScore_2;
            }

            float averageScoreToFloat = float.TryParse(averageScore, out averageScoreToFloat) ? averageScoreToFloat : 0;
            match.AverageScore = averageScoreToFloat;

            string[] teamsSplit = teams.Split(new[] { "<br>" }, StringSplitOptions.None);
            match.Team1 = teamsSplit[0].Trim();
            match.Team2 = teamsSplit[1].Trim();


            int splitFinalScore1 = 0;
            int splitFinalScore2 = 0;
            if (!string.IsNullOrEmpty(finalScore))
            {
                string[] split = finalScore.Trim().Split('(');
                string[] splitFinalScore = split[0].Split('-');
                int.TryParse(splitFinalScore[0], out splitFinalScore1);
                int.TryParse(splitFinalScore[1], out splitFinalScore2);
            }
            match.Team1Goals = splitFinalScore1;
            match.Team2Goals = splitFinalScore2;

            return match;
        }

        public void AddOrUpdateMatch(MatchResult match, string league)
        {
            MatchRepository matchRepo = new MatchRepository();
            MatchResult matchFound = matchRepo.FindByDateAndTeams(match.Date, match.Team1, match.Team2);
            if (matchFound == null)
            {
                matchRepo.Add(match, league);
            }
            else
            {
                matchRepo.Update(match, league);
            }
        }

        //NOT USED DEPRECATED
        public string GetHTMLFromUrl(ForebetUrl url)
        {
            string html = string.Empty;
            Uri urlAddress = url.Uri;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                html = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }

            return html;
        }
        //NOT USED DEPRECATED
        public void FizzlerTest(string htmllel)
        {
            var html = new HtmlDocument();
            html.LoadHtml(@htmllel);

            // Fizzler for HtmlAgilityPack is implemented as the 
            // QuerySelectorAll extension method on HtmlNode

            var document = html.DocumentNode;

            var body = document.QuerySelectorAll("body").FirstOrDefault();
            var rows = body.QuerySelectorAll(".tr_0").ToList();
            rows.AddRange(body.QuerySelectorAll(".tr_1").ToList());

            foreach (var row in rows)
            {
                var tds = row.ChildNodes.Where(x => x.Name == "td");

                var td1 = row.QuerySelectorAll(".tnms a").ToList();
                //foreach (var td in tds)
                //{
                //    var teams = td.QuerySelectorAll("a").Where(x => x.Attributes.Where(a => a.Name == "class"));
                //}
            }


        }
    }
}
