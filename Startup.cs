using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationRB
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
            services.AddMvc();
            services.AddControllersWithViews();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddDbContext<Data.ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnString")));
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
            }


            
            List<CultureInfo> supportedCultures = new List<CultureInfo>();
            var allowedCultures =  Configuration.GetSection("allowedCultures").Get<string[]>();
            //var defaultCulture = new CultureInfo(Configuration["SiteLocale"]);

            foreach (var ci in allowedCultures)
            {
                CultureInfo cultureInfo = new CultureInfo(ci);
                cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
                cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
                cultureInfo.NumberFormat.NumberGroupSeparator = ",";
                supportedCultures.Add(cultureInfo);
            }

           

            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(Configuration["SiteLocale"]),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };
            app.UseRequestLocalization(localizationOptions);

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization() ; 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
          

            
            
        }
    }
}
