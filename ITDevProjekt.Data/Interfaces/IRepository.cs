using System;
using System.Collections.Generic;
using System.Text;

namespace ITDevProjekt.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Func<T, bool> predicate);

        T GetById(int id);

        T GetByToken(string token);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        int Count(Func<T, bool> predicate);
    }
}
