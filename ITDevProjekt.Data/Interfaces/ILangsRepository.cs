using ITDevProjekt.Data.Models;
using System.Collections.Generic;

namespace ITDevProjekt.Data.Interfaces
{
    public interface ILangsRepository : IRepository<Langs>
    {
        new IEnumerable<Langs> GetAll();
    }
}
