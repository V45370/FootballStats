using System.Collections.Generic;
using Models;
using System;

namespace Repos
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> List { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(int Id);
        //T FindByDateAndTeams(DateTime date, string Team1, string Team2); // THIS SHOULD BE DELETED
    }
}
