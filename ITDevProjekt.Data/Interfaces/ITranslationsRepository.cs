using ITDevProjekt.Data.Models;
using System;
using System.Collections.Generic;

namespace ITDevProjekt.Data.Interfaces
{
    public interface ITranslationsRepository : IRepository<Translations>
    {
        IEnumerable<Translations> GetAllWithToken();

        IEnumerable<Translations> GetWithToken(string token);

    }
}
