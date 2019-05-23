using ITDevProjekt.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ITDevProjekt.Data.Models
{
    public class LangContextFactory : IDesignTimeDbContextFactory<ProjektDbContext>
    {

        public ProjektDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjektDbContext>();

            IConfiguration conf = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ITDevProjekt"))
                .AddJsonFile("appsettings.json")
                .Build();

            var optionBuilder = new DbContextOptionsBuilder<ProjektDbContext>();

            optionsBuilder.UseMySQL(conf.GetConnectionString("DefaultConnection"));

            return new ProjektDbContext(optionsBuilder.Options);
        }
    }
}