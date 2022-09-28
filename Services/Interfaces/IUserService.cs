using avarice_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;

namespace avarice_backend.Services.Interfaces
{
  public interface IUserService
  {
    ClaimsPrincipal GetUser();
  }
}