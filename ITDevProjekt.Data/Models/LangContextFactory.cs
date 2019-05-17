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
    public class LangContextFactory : IDesignTimeDbContextFactory<LangContext> { 

        public LangContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LangContext>();

            IConfiguration conf = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ITDevProjekt"))
                .AddJsonFile("appsettings.json")
                .Build();

            var optionBuilder = new DbContextOptionsBuilder<LangContext>();

            optionsBuilder.UseMySQL(conf.GetConnectionString("DefaultConnection"));

            return new LangContext(optionsBuilder.Options);
        }
    }
}
