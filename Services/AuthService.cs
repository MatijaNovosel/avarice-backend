using System;
using System.Threading.Tasks;
using fin_app_backend.Services.Interfaces;
using fin_app_backend.Repositories.Interfaces;
using fin_app_backend.Models;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace fin_app_backend.Services
{
  public class AuthService : IAuthService
  {
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _accessor;
    public IConfiguration Configuration { get; }

    public AuthService(UserManager<User> userManager, IConfiguration configuration, IHttpContextAccessor accessor)
    {
      _userManager = userManager;
      Configuration = configuration;
      _accessor = accessor;
    }

    public async Task<AuthResultModel> Register(RegistrationModel payload)
    {
      var user = await _userManager.FindByEmailAsync(payload.Email);

      if (user != null)
      {
        return new AuthResultModel()
        {
          Result = false,
          Errors = new List<string>() { "User with that email already exist!" }
        };
      }

      var newUser = new User()
      {
        Email = payload.Email,
        UserName = payload.Username
      };

      var isCreated = await _userManager.CreateAsync(newUser, payload.Password);

      if (isCreated.Succeeded)
      {
        var jwtToken = GenerateJwtToken(newUser);
        return new AuthResultModel()
        {
          Result = true,
          Token = jwtToken
        };
      }

      return new AuthResultModel()
      {
        Result = false,
        Errors = new List<string>() { "Failed to create user!" }
      };
    }

    public async Task<AuthResultModel> Login(LoginModel payload)
    {
      var user = await _userManager.FindByEmailAsync(payload.Email);

      if (user == null)
      {
        return new AuthResultModel()
        {
          Result = false,
          Errors = new List<string>() { "User with that email does not exist!" }
        };
      }

      bool correctPassword = await _userManager.CheckPasswordAsync(user, payload.Password);

      if (!correctPassword)
      {
        return new AuthResultModel()
        {
          Result = false,
          Errors = new List<string>() { "Incorrect password!" }
        };
      }

      var jwtToken = GenerateJwtToken(user);

      return new AuthResultModel()
      {
        Token = jwtToken,
        Result = true
      };
    }

    public ClaimsPrincipal GetUser()
    {
      return _accessor?.HttpContext?.User as ClaimsPrincipal;
    }

    private string GenerateJwtToken(User user)
    {
      var jwtTokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(Configuration["SecretKey"]);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[]
        {
          new Claim("Id", user.Id),
          new Claim(JwtRegisteredClaimNames.Sub, user.Email),
          new Claim(JwtRegisteredClaimNames.Email, user.Email)
        }),
        Expires = DateTime.UtcNow.AddHours(6),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
      };
      var token = jwtTokenHandler.CreateToken(tokenDescriptor);
      var jwtToken = jwtTokenHandler.WriteToken(token);
      return jwtToken;
    }
  }
}