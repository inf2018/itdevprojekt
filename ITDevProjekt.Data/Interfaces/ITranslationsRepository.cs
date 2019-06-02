using ITDevProjekt.Data.Models;
using System;
using System.Collections.Generic;

namespace ITDevProjekt.Data.Interfaces
{
    public interface ITranslationsRepository : IRepository<Translations>
    {
        IEnumerable<Translations> GetAllWithToken(string token);

        IEnumerable<Translations> GetWithToken(string token);

        IEnumerable<Translations> GetById(int id);
        object Where(Func<object, object> p);
    }
}
