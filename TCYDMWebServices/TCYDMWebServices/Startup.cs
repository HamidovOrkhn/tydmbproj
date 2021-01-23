using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Prometheus;
using TCYDMWebServices.Data;
using TCYDMWebServices.DTO;
using TCYDMWebServices.Repositories.Abstracts;
using TCYDMWebServices.Repositories.Repos;

namespace TCYDMWebServices
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
            services.AddControllers();
            services.AddSwaggerDocument();
            services.AddTransient<ITransactions<UserDTO>,UserRepos>();
            services.AddTransient<ITransactions<OnlineQueryDTO>, OnlineQueryRepos>();
            services.AddDbContext<DatabaseContext>(a => a.UseSqlServer(Configuration.GetConnectionString("DatabaseContext")));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = Configuration["Jwt:Issuer"],
                     ValidAudience = Configuration["Jwt:Issuer"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                 };
             });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseOpenApi();

            app.UseSwaggerUi3();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            var counter = Metrics.CreateCounter("peopleapi_path_counter", "Counts requests to the People API endpoints", new CounterConfiguration
            {
                LabelNames = new[] { "method", "endpoint" }
            });
            app.Use((context, next) =>
            {
                counter.WithLabels(context.Request.Method, context.Request.Path).Inc();
                return next();
            });
            // Use the Prometheus middleware
            app.UseMetricServer();
            app.UseHttpMetrics();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
