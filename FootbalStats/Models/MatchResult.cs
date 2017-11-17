using System;
using System.Text;

namespace Models
{
    public class MatchResult : IEntity
    {
        public int Id { get; set; }
        //public Season Season { get; set; }
        public virtual League League { get; set; }
        public DateTime Date { get; set; }
        public int Percentage1 { get; set; }
        public int PercentageX { get; set; }
        public int Percentage2 { get; set; }
        public string Prediction { get; set; }
        public int ExactScore1 { get; set; }
        public int ExactScore2 { get; set; }
        public float AverageScore { get; set; }
        //public Team Team1 { get; set; } //TODO entity
        //public Team Team2 { get; set; }   //TODO entity
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public int Team1Goals { get; set; }
        public int Team2Goals { get; set; }
        //public decimal HomeTeamCorners { get; set; }
        //public decimal AwayTeamCorners { get; set; }  
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Date.ToString("dd/MM/yyyy HH:mm"));
            sb.Append(" ");
            if (League != null) sb.Append("[" + League.Name + "]");
            sb.Append(Team1);
            sb.Append(" - ");
            sb.Append(Team2);
            sb.Append(" ");
            sb.Append(ExactScore1);
            sb.Append(" - ");
            sb.Append(ExactScore2);

            return sb.ToString();
        }
    }
}
