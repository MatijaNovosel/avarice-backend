using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using fin_app_backend.Repositories.Base;
using fin_app_backend.Repositories;
using fin_app_backend.Repositories.Interfaces;
using fin_app_backend.Services;
using fin_app_backend.Services.Interfaces;
using AutoMapper;

namespace fin_app_backend
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      var serverVersion = new MySqlServerVersion(new Version(8, 0, 21));
      services.AddDbContext<finappContext>(
          dbContextOptions => dbContextOptions
              .UseMySql(Configuration["ConnectionString"], serverVersion)
              .EnableSensitiveDataLogging()
              .EnableDetailedErrors()
      );

      // Repositories
      services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
      services.AddScoped<ITagRepository, TagRepository>();
      services.AddScoped<ITransactionRepository, TransactionRepository>();
      services.AddScoped<ITransactionTagRepository, TransactionTagRepository>();
      services.AddScoped<IAccountRepository, AccountRepository>();
      services.AddScoped<IHistoryRepository, HistoryRepository>();

      // Service layer
      services.AddScoped<ITagService, TagService>();
      services.AddScoped<ITransactionService, TransactionService>();
      services.AddScoped<IHistoryService, HistoryService>();

      services.AddAutoMapper(typeof(Startup));

      services.AddControllers();
      services.AddSwaggerDocument();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseOpenApi();
        app.UseSwaggerUi3();
      }
      app.UseHttpsRedirection();
      app.UseRouting();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
