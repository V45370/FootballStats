using System.Collections.Generic;

namespace Models
{
    public class League : IEntity
    {
        public League()
        {
            //Seasons = new List<Season>();
            Matches = new List<MatchResult>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        //public virtual IList<Season> Seasons { get; set; }
        public virtual IList<MatchResult> Matches { get; set; }

    }
}
