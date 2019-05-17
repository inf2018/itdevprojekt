using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITDevProjekt.Data.Models
{
    public class LangContext : DbContext
    {
        public LangContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Langs> Langs { get; set; }
    }
}
