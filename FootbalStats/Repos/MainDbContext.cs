using Models;
using System.Data.Entity;

namespace Repos
{
    public class MainDbContext : DbContext
    {
        public MainDbContext()
            : base("FootballStats")
        {

        }

        public virtual IDbSet<MatchResult> Matches { get; set; }
        public virtual IDbSet<League> Leagues { get; set; }
        public virtual IDbSet<SoccerStatGoalByMinute> SoccerStatsGoalByMinute { get; set; }
        //public virtual IDbSet<Team> Teams { get; set; }
        //public virtual IDbSet<Season> Seasons { get; set; }
    }
}
