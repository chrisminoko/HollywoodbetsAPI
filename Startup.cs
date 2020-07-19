using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using SportAPISever.Model;
using SportAPISever.Context;
using SportAPISever.Contracts;
using SportAPISever.Data_Manager;
using Swashbuckle.AspNetCore;
using System.Reflection;
using System.IO;
using Microsoft.OpenApi.Models;
namespace SportAPISever
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllers();
            services.AddDbContext<HollywoodbetsDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Devcon")));

            services.AddScoped<ISportType, SportTypeDataManager>();
            services.AddScoped<ICountry, CountryDataManager>();
            services.AddScoped<ITournament, TournamentDataManager>();
            services.AddScoped<IEvents, EventsDataManager>();
            services.AddScoped<IBetType, BetTypeDataManager>();
            services.AddScoped<IMarket, MarketDataManager>();
            services.AddScoped<IEventMarket, EventMarketType>();
            services.AddScoped<IOddsDetails, OddsDataManager>();
            services.AddScoped<ISportCountry, SportCountryDataManager>();
            services.AddScoped<ISportTournament, SportTournamentDataManager>();
            services.AddScoped<IBettyepeMarkets, BettyepeMarketsDataManager>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "A simple example ASP.NET Core Web API",
                });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("MyPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            loggerFactory.AddLog4Net();
        }
    }
}
