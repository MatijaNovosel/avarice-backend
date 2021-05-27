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
using fin_app_backend.Authorization;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using NSwag.Generation.Processors.Security;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

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

      services.AddCors(options =>
      {
        options.AddDefaultPolicy(
          builder =>
          {
            builder
              .WithOrigins("http://localhost:8080", "https://localhost:8080", "null")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
          });
      });

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
      services.AddScoped<IUserService, UserService>();
      services.AddScoped<IAuthService, AuthService>();
      services.AddScoped<IAccountService, AccountService>();

      services.AddAutoMapper(typeof(Startup));

      services.AddAuthorization(options =>
      {
        options.AddPolicy("UserMustBeAuthor", policy => policy.Requirements.Add(new UserMustBeAuthorRequirement()));
      });

      services.AddTransient<IAuthorizationHandler, UserAuthorHandler>();

      services.AddHttpsRedirection(options =>
      {
        options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
        options.HttpsPort = 5001;
      });

      services.AddControllers();
      services.AddSwaggerDocument(settings =>
      {
        settings.Title = "FinApp API";
        settings.AddSecurity("Bearer", new NSwag.OpenApiSecurityScheme
        {
          Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
          Name = "Authorization",
          In = NSwag.OpenApiSecurityApiKeyLocation.Header,
          Type = NSwag.OpenApiSecuritySchemeType.ApiKey,
          Scheme = "bearer"
        });
        settings.OperationProcessors.Add(new OperationSecurityScopeProcessor("Bearer"));
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
      app.UseCors();
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
