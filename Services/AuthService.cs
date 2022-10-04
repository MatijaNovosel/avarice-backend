using System;
using System.Threading.Tasks;
using avarice_backend.Services.Interfaces;
using avarice_backend.Repositories.Interfaces;
using avarice_backend.Models;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using avarice_backend.Utils;
using System.Linq;

namespace avarice_backend.Services
{
  public class AuthService : IAuthService
  {
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _accessor;
    private readonly IConfiguration _configuration;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ISettingsRepository _settingsRepository;

    public AuthService(
      UserManager<User> userManager,
      IConfiguration configuration,
      IHttpContextAccessor accessor,
      ICategoryRepository categoryRepository,
      ISettingsRepository settingsRepository
    )
    {
      _userManager = userManager;
      _configuration = configuration;
      _accessor = accessor;
      _categoryRepository = categoryRepository;
      _settingsRepository = settingsRepository;
    }

    public async Task<RegisterResult> Register(RegistrationModel payload)
    {
      var user = await _userManager.FindByEmailAsync(payload.Email);

      if (user != null)
      {
        return new RegisterResult()
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
        // Assign preset categories to the newly created user
        foreach (KeyValuePair<Category, List<Category>> entry in PresetCategories.CategoriesDictionary)
        {
          var newParentCategory = new Category()
          {
            UserId = newUser.Id,
            Color = "#ffffff",
            Icon = entry.Key.Icon,
            Name = entry.Key.Name
          };

          await _categoryRepository.AddAsync(newParentCategory);

          foreach (var c in entry.Value)
          {
            await _categoryRepository.AddAsync(new Category()
            {
              UserId = newUser.Id,
              Color = "#ffffff",
              Icon = c.Icon,
              Name = c.Name,
              ParentId = newParentCategory.Id
            });
          }
        }

        await _settingsRepository.AddAsync(new Settings()
        {
          AccentColor = "#ad2d1c",
          UserId = newUser.Id
        });

        return new RegisterResult()
        {
          Result = true,
        };
      }

      return new RegisterResult()
      {
        Result = false,
        Errors = new List<string>() { "Failed to create user!" }
      };
    }

    public async Task<LoginResult> Login(LoginModel payload)
    {
      var user = await _userManager.FindByEmailAsync(payload.Email);

      if (user == null)
      {
        return new LoginResult()
        {
          Result = false,
          Errors = new List<string>() { "Incorrect credentials!" }
        };
      }

      bool correctPassword = await _userManager.CheckPasswordAsync(user, payload.Password);

      if (!correctPassword)
      {
        return new LoginResult()
        {
          Result = false,
          Errors = new List<string>() { "Incorrect credentials!" }
        };
      }

      var jwtToken = GenerateJwtToken(user);

      return new LoginResult()
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
      var key = Encoding.ASCII.GetBytes(_configuration["SecretKey"]);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[]
        {
          new Claim("Id", user.Id),
          new Claim(JwtRegisteredClaimNames.Email, user.Email),
          new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
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