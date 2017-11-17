using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repos
{
    public class MatchRepository : IRepository<MatchResult>
    {

        MainDbContext _context;

        public MatchRepository()
        {
            _context = new MainDbContext();

        }
        public IEnumerable<MatchResult> List
        {
            get
            {
                return _context.Matches;
            }

        }

        public void Add(MatchResult entity)
        {
            _context.Matches.Add(entity);
            _context.SaveChanges();
        }

        public void Add(MatchResult match, string league)
        {
            var foundLeague = (from r in _context.Leagues where r.Name == league select r).FirstOrDefault();
            match.League = foundLeague;
            _context.Matches.Add(match);
            _context.SaveChanges();
        }

        public void Delete(MatchResult entity)
        {
            _context.Matches.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(MatchResult entity, string league)
        {
            MatchResult found = FindByDateAndTeams(entity.Date, entity.Team1, entity.Team2);
            if (CheckPropertyChange(ref found, entity))
            {
                try
                {
                    _context.Entry(found).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                }
                catch (InvalidOperationException ex)
                {
                    //fuck you
                }

            }
            if (LeagueChange(ref found, entity, league))
            {
                try
                {
                    _context.Entry(found).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                }
                catch (InvalidOperationException ex)
                {
                    //fuck you
                }

            }

        }

        public MatchResult FindById(int Id)
        {
            var result = (from r in _context.Matches where r.Id == Id select r).FirstOrDefault();
            return result;
        }

        public MatchResult FindByDateAndTeams(DateTime date, string Team1, string Team2)
        {
            DateTime fromDate = date.AddDays(-30);
            DateTime toDate = date.AddDays(30);

            var result = _context.Matches.Where(m => m.Date < toDate
                                                && m.Date > fromDate
                                                && m.Team1 == Team1
                                                && m.Team2 == Team2).FirstOrDefault();
            return result;
        }

        private bool CheckPropertyChange(ref MatchResult found, MatchResult entity)
        {
            bool change = false;

            if (found.Date != entity.Date
                || found.Team1Goals != entity.Team1Goals
                || found.Team2Goals != entity.Team2Goals
                || found.Percentage1 != entity.Percentage1
                || found.PercentageX != entity.PercentageX
                || found.Percentage2 != entity.Percentage2
                || found.ExactScore1 != entity.ExactScore1
                || found.ExactScore2 != entity.ExactScore2
                || found.AverageScore != entity.AverageScore)
            {
                change = true;
                found.Date = entity.Date;
                found.Team1Goals = entity.Team1Goals;
                found.Team2Goals = entity.Team2Goals;
                found.Percentage1 = entity.Percentage1;
                found.PercentageX= entity.PercentageX;
                found.Percentage2 = entity.Percentage2;
                found.ExactScore1 = entity.ExactScore1;
                found.ExactScore2 = entity.ExactScore2;
                found.AverageScore= entity.AverageScore;
            }

            return change;
        }
        private bool LeagueChange(ref MatchResult found, MatchResult entity, string league)
        {
            bool change = false;

            if (found.League != null
                && entity.League != null
                && found.League.Name != entity.League.Name)
            {
                found.League = entity.League;
                change = true;
            }

            return change;
        }

        public void Update(MatchResult entity)
        {
            throw new NotImplementedException();
        }
    }
}
