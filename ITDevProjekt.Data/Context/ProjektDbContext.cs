using ITDevProjekt.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ITDevProjekt.Data.Context
{
    public class ProjektDbContext : DbContext
    {
        public ProjektDbContext(DbContextOptions<ProjektDbContext> options) : base(options)
        {

        }
        public DbSet<Langs> Langs { get; set; }
        public DbSet<Translations> Translations { get; set; }
    }
}
