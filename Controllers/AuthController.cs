using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using avarice_backend.Services.Interfaces;
using avarice_backend.Models;
using Microsoft.Extensions.Configuration;

namespace avarice_backend.Controllers
{
  [ApiController]
  [Route("api/auth")]
  public class AuthController : ControllerBase
  {
    private readonly AvariceContext _context;
    private readonly IAuthService _authService;
    private readonly IConfiguration _configuration;

    public AuthController(AvariceContext context, IAuthService authService, IConfiguration configuration)
    {
      _context = context;
      _authService = authService;
      _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<RegisterResult> Register(RegistrationModel payload)
    {
      var data = await _authService.Register(payload);
      return data;
    }

    [HttpPost("login")]
    public async Task<LoginResult> Login(LoginModel payload)
    {
      var data = await _authService.Login(payload);
      return data;
    }

    [HttpGet("settings")]
    public IActionResult Settings()
    {
      return Ok(_configuration["ConnectionString"]);
    }
  }
}
