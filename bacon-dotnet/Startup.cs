using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BxAAS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        
            services.AddMvc(options => {
                options.EnableEndpointRouting = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
app.UseMvc(config =>{
config.MapRoute(
                "ApiHelp",
                "Help",
                new { controller = "Home", action = "Help" });
            config.MapRoute(
             "PirateBacon",
             "Yarr",
             new { controller = "Bacon", action = "Pirate" });
            config.MapRoute(
                "BaconCooker",
                "Cook",
                new { controller = "Bacon", action = "Cook" });
            config.MapRoute(
                "BaconComa",
                "Coma",
                new { controller = "Bacon", action = "Coma" });
            config.MapRoute(
                "BaconFlip",
                "Flip/{flipCount?}",
                new { controller = "Bacon", action = "Flip" });
            config.MapRoute(
                "Default",
                "{controller}/{action}/{id?}",
                new { controller="Home", action="Index" }
            );

            });
        }
    }
}
