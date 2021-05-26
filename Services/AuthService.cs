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

namespace fin_app_backend.Services
{
  public class AuthService : IAuthService
  {
    private readonly IUserRepository _userRepository;
    public IConfiguration Configuration { get; }

    public AuthService(IUserRepository userRepository, IConfiguration configuration)
    {
      _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
      Configuration = configuration;
    }

    public async Task<AuthResultModel> Register(RegistrationModel payload)
    {
      bool userExists = await _userRepository.UserExistsByEmail(payload.Email);

      if (userExists)
      {
        throw new Exception("User already exists!");
      }

      var newUser = new User()
      {
        Email = payload.Email,
        UserName = payload.Username
      };

      var jwtToken = GenerateJwtToken(newUser);

      return new AuthResultModel()
      {
        Result = true,
        Token = jwtToken
      };
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