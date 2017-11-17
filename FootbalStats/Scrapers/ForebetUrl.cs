using System;

namespace FootbalStats.Scrapers
{
    public class ForebetUrl
    {
        public ForebetUrl(string league, string uri)
        {
            League = league;
            Uri = new Uri(uri);
        }
        public string League { get; set; }
        public Uri Uri { get; set; }
    }
}
