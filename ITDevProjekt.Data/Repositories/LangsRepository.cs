using ITDevProjekt.Data.Context;
using ITDevProjekt.Data.Interfaces;
using ITDevProjekt.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITDevProjekt.Data.Repositories
{
    public class LangsRepository : Repository<Langs>, ILangsRepository
    {
        public LangsRepository(ProjektDbContext context) : base(context)
        {

        }
        public new IEnumerable<Langs> GetAll()
        {
            return _context.Set<Langs>();
        }   
    }
}
