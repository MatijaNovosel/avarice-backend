using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using fin_app_backend.Services.Interfaces;
using fin_app_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;

namespace fin_app_backend.Controllers
{
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  [ApiController]
  [Route("api/template")]
  public class TemplateController : ControllerBase
  {
    private readonly finappContext _context;
    private readonly ITemplateService _templateService;

    public TemplateController(finappContext context, ITemplateService templateService)
    {
      _context = context;
      _templateService = templateService;
    }

    [HttpPost]
    public async Task Add(AddTemplateDto payload)
    {
      await _templateService.AddTemplate(payload, ((ClaimsIdentity)User.Identity).FindFirst("Id").Value);
    }

    [HttpDelete("{id}")]
    public async Task Delete(long id)
    {
      await _templateService.DeleteTemplate(((ClaimsIdentity)User.Identity).FindFirst("Id").Value, id);
    }

    [HttpGet]
    public async Task<PageableCollection<TemplateModel>> Get(int skip, int take)
    {
      var data = await _templateService.GetAll(((ClaimsIdentity)User.Identity).FindFirst("Id").Value);
      var count = await _templateService.GetCount(((ClaimsIdentity)User.Identity).FindFirst("Id").Value);

      return new PageableCollection<TemplateModel>()
      {
        Results = data,
        Total = count
      };
    }
  }
}
