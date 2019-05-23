using ITDevProjekt.Data.Context;
using ITDevProjekt.Data.Interfaces;
using ITDevProjekt.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ITDevProjekt.Data.Repositories
{
    public class TranslationsRepository : Repository<Translations>, ITranslationsRepository
    {
        public TranslationsRepository(ProjektDbContext context) : base(context)
        {

        }
        public IEnumerable<Translations> GetAllWithToken()
        {
            return _context.Translations.Include(a => a.TextToken);
        }

        public IEnumerable<Translations> GetWithToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
