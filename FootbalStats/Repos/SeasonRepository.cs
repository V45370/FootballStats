using Models;
using System.Collections.Generic;
using System.Linq;

namespace Repos
{
    //public class SeasonRepository : IRepository<Season>
    //{

    //    MainDbContext _context;

    //    public SeasonRepository()
    //    {
    //        _context = new MainDbContext();

    //    }
    //    public IEnumerable<Season> List
    //    {
    //        get
    //        {
    //            return _context.Seasons;
    //        }

    //    }

    //    public void Add(Season entity)
    //    {
    //        _context.Seasons.Add(entity);
    //        _context.SaveChanges();
    //    }

    //    public void Delete(Season entity)
    //    {
    //        _context.Seasons.Remove(entity);
    //        _context.SaveChanges();
    //    }

    //    public void Update(Season entity)
    //    {
    //        _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
    //        _context.SaveChanges();

    //    }

    //    public Season FindById(int Id)
    //    {
    //        var result = (from r in _context.Seasons where r.Id == Id select r).FirstOrDefault();
    //        return result;
    //    }

    //    public Season FindByName(string name)
    //    {
    //        var result = (from r in _context.Seasons where r.Name == name select r).FirstOrDefault();
    //        return result;
    //    }
    //}
}
