using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using TCYDMWebApp.Repositories.Lang;

namespace TCYDMWebApp
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
            services.AddMvc().AddNewtonsoftJson()
            .AddDataAnnotationsLocalization(options => {
            options.DataAnnotationLocalizerProvider = (type, factory) =>
                factory.Create(typeof(SharedResource));
        });
            
            services.Configure<RequestLocalizationOptions>(opts => {
                var supportedCultures = new List<CultureInfo> {
                    new CultureInfo("en"),
                    new CultureInfo("en-US"),
                    new CultureInfo("fr"),
                    new CultureInfo("ru"),
                    new CultureInfo("ja"),
                    new CultureInfo("fr-FR"),
                    new CultureInfo("zh-CN"),   // Chinese China
                    new CultureInfo("ar-EG"),   // Arabic Egypt
                  };

                opts.DefaultRequestCulture = new RequestCulture("en-US");
                // Formatting numbers, dates, etc.
                opts.SupportedCultures = supportedCultures;
                // UI strings that we have localized.
                opts.SupportedUICultures = supportedCultures;
            });
            services.AddSession();
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
            app.UseStaticFiles();

            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();

            app.UseRequestLocalization(options.Value);

            app.UseRouting();

            app.UseCookiePolicy();

            app.UseSession();

            app.UseAuthorization();

          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}