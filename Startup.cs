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
using avarice_backend.Repositories.Base;
using avarice_backend.Repositories;
using avarice_backend.Repositories.Interfaces;
using avarice_backend.Services;
using avarice_backend.Services.Interfaces;
using avarice_backend.Authorization;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using NSwag.Generation.Processors.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace avarice_backend
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    private readonly IConfiguration _configuration;

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(jwt =>
      {
        var key = Encoding.ASCII.GetBytes(_configuration["SecretKey"]);

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

      var serverVersion = new MySqlServerVersion(new Version(8, 0, 21));
      services.AddDbContext<AvariceContext>(
          dbContextOptions => dbContextOptions
              .UseMySql(_configuration["ConnectionString"], serverVersion)
              .EnableSensitiveDataLogging()
              .EnableDetailedErrors()
      );

      services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AvariceContext>();

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
      services.AddScoped<ITransactionRepository, TransactionRepository>();
      services.AddScoped<IAccountRepository, AccountRepository>();
      services.AddScoped<ICategoryRepository, CategoryRepository>();
      services.AddScoped<ITemplateRepository, TemplateRepository>();

      // Service layer
      services.AddScoped<ITransactionService, TransactionService>();
      services.AddScoped<IUserService, UserService>();
      services.AddScoped<IAuthService, AuthService>();
      services.AddScoped<IAccountService, AccountService>();
      services.AddScoped<ICategoryService, CategoryService>();
      services.AddScoped<ITemplateService, TemplateService>();

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
        settings.Title = "Avarice API";
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
      app.UseHttpsRedirection();
      app.UseRouting();
      app.UseCors();
      app.UseAuthentication();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
