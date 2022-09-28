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

namespace avarice_backend.Services
{
  public class UserService : IUserService
  {
    private readonly IHttpContextAccessor _accessor;

    public UserService(IHttpContextAccessor accessor)
    {
      _accessor = accessor;
    }

    public ClaimsPrincipal GetUser()
    {
      return _accessor?.HttpContext?.User as ClaimsPrincipal;
    }
  }
}