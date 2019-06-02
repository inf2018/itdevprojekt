using ITDevProjekt.Data.Context;
using ITDevProjekt.Data.Interfaces;
using ITDevProjekt.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ITDevProjekt.Data.Repositories
{
    public class TranslationsRepository : Repository<Translations>, ITranslationsRepository
    {
        public TranslationsRepository(ProjektDbContext context) : base(context)
        {

        }
        public IEnumerable<Translations> GetAllWithToken(string token)
        {
            //return _context.Translations.Include(a => a.TextToken.Contains(token));
            var trans = _context.Translations.Where(x => x.TextToken == token).ToList();
            //return _context.Translations.Include(a => a.TextToken);
            return trans;
        }

        public IEnumerable<Translations> GetWithToken(string token)
        {
            var trans = _context.Translations.Where(x => x.TextToken.Contains(token)).ToList();
            return trans;
        }

        public IEnumerable<Translations> GetById(int id)
        {
            return _context.Translations.Include(a => a.Id);
        }

        public object Where(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
