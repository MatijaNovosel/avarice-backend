

using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Microsoft.AspNetCore.Http;

namespace avarice_backend.Authorization
{
  public class UserAuthorHandler : AuthorizationHandler<UserMustBeAuthorRequirement>
  {
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserAuthorHandler(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserMustBeAuthorRequirement requirement)
    {
      var userId = _httpContextAccessor.HttpContext.Request.Query["userId"];
      var currentUserId = context.User.FindFirst("id")?.Value;

      if (userId == currentUserId)
      {
        context.Succeed(requirement);
      }
      else
      {
        context.Fail();
      }

      return Task.CompletedTask;
    }
  }
}