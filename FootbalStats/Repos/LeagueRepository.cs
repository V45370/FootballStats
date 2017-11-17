using Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Repos
{
    public class LeagueRepository : IRepository<League>
    {

        MainDbContext _context;

        public LeagueRepository()
        {
            _context = new MainDbContext();

        }
        public IEnumerable<League> List
        {
            get
            {
                return _context.Leagues;
            }

        }

        public void Add(League entity)
        {
            _context.Leagues.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(League entity)
        {
            _context.Leagues.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(League entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

        }

        public League FindById(int Id)
        {
            var result = (from r in _context.Leagues where r.Id == Id select r).FirstOrDefault();
            return result;
        }

        public League FindByName(string name)
        {
            var result = (from r in _context.Leagues where r.Name == name select r).FirstOrDefault();
            return result;
        }
    }
}
