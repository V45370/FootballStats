using System.Text;

namespace Models
{
    public class SoccerStatGoalByMinute : IEntity
    {
        public int Id { get; set; }
        public string Team { get; set; }
        public int Do10Scored { get; set; }
        public int Do20Scored { get; set; }
        public int Do30Scored { get; set; }
        public int Do40Scored { get; set; }
        public int Do50Scored { get; set; }
        public int Do60Scored { get; set; }
        public int Do70Scored { get; set; }
        public int Do80Scored { get; set; }
        public int Do90Scored { get; set; }
        public int Do10Conceded { get; set; }
        public int Do20Conceded { get; set; }
        public int Do30Conceded { get; set; }
        public int Do40Conceded { get; set; }
        public int Do50Conceded { get; set; }
        public int Do60Conceded { get; set; }
        public int Do70Conceded { get; set; }
        public int Do80Conceded { get; set; }
        public int Do90Conceded { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("|10|20|30|40|50|60|70|80|90|");
            sb.Append("|");
            if (Do10Scored < 10) sb.Append(" " + Do10Scored + "|");
            else sb.Append(Do10Scored + "|");
            if (Do20Scored < 10) sb.Append(" " + Do20Scored + "|");
            else sb.Append(Do20Scored + "|");
            if (Do30Scored < 10) sb.Append(" " + Do30Scored + "|");
            else sb.Append(Do30Scored + "|");
            if (Do40Scored < 10) sb.Append(" " + Do40Scored + "|");
            else sb.Append(Do40Scored + "|");
            if (Do50Scored < 10) sb.Append(" " + Do50Scored + "|");
            else sb.Append(Do50Scored + "|");
            if (Do60Scored < 10) sb.Append(" " + Do60Scored + "|");
            else sb.Append(Do60Scored + "|");
            if (Do70Scored < 10) sb.Append(" " + Do70Scored + "|");
            else sb.Append(Do70Scored + "|");
            if (Do80Scored < 10) sb.Append(" " + Do80Scored + "|");
            else sb.Append(Do80Scored + "|");
            if (Do90Scored < 10) sb.Append(" " + Do90Scored + "|");
            else sb.Append(Do90Scored + "|");
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
