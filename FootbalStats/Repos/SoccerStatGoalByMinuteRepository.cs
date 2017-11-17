using Models;
using Repos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootbalStats.Repos
{
    public class SoccerStatGoalByMinuteRepository : IRepository<SoccerStatGoalByMinute>
    {

        MainDbContext _context;

        public SoccerStatGoalByMinuteRepository()
        {
            _context = new MainDbContext();

        }


        public IEnumerable<SoccerStatGoalByMinute> List
        {
            get
            {
                return _context.SoccerStatsGoalByMinute;
            }
        }

        public void Add(SoccerStatGoalByMinute entity)
        {
            _context.SoccerStatsGoalByMinute.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(SoccerStatGoalByMinute entity)
        {
            _context.SoccerStatsGoalByMinute.Remove(entity);
            _context.SaveChanges();
        }

        public SoccerStatGoalByMinute FindById(int Id)
        {
            var result = (from r in _context.SoccerStatsGoalByMinute where r.Id == Id select r).FirstOrDefault();
            return result;
        }

        public SoccerStatGoalByMinute FindByTeam(string team)
        {
            var result = (from r in _context.SoccerStatsGoalByMinute where r.Team == team select r).FirstOrDefault();
            return result;
        }

        public void Update(SoccerStatGoalByMinute entity)
        {
            throw new NotImplementedException();
        }
    }
}
