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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;

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

      services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(jwt =>
      {
        var key = Encoding.ASCII.GetBytes(Configuration["SecretKey"]);

        jwt.SaveToken = true;
        jwt.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false,
          RequireExpirationTime = false,
          ValidateLifetime = true
        };
      });

      services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<finappContext>();

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
      services.AddScoped<IAuthService, AuthService>();

      services.AddAutoMapper(typeof(Startup));

      services.AddControllers();
      services.AddSwaggerDocument(settings =>
      {
        settings.Title = "FinApp API";
        settings.AddSecurity("Bearer", new NSwag.OpenApiSecurityScheme
        {
          Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
          Name = "Authorization",
          In = NSwag.OpenApiSecurityApiKeyLocation.Header,
          Type = NSwag.OpenApiSecuritySchemeType.ApiKey
        });
      });
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
      app.UseAuthentication();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
