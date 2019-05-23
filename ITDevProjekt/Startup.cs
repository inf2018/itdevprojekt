using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITDevProjekt.Data.Models;
using ITDevProjekt.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ITDevProjekt.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using ITDevProjekt.Data.Interfaces;
using ITDevProjekt.Data.Repositories;
using System.Diagnostics;

namespace ITDevProjekt
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ILangsRepository, LangsRepository>();
            services.AddTransient<ITranslationsRepository, TranslationsRepository>();
            services.AddSingleton<IConfiguration>(Configuration);

            //var connection = Configuration["DefaultConnection"];
            var connection = "SERVER=localhost;Database=test2;UID=newuser1;Password=123456789admin;";
            services.AddDbContext<ProjektDbContext>(options => options.UseMySQL(connection)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            //services.AddScoped<IMyDbContext, MyDbContext>();

            //services.Configure<Language>(Configuration.GetSection("ConnectionStrings"));
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
