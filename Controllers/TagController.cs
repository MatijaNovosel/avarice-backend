using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using fin_app_backend.Services.Interfaces;
using fin_app_backend.Models;

namespace fin_app_backend.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TagController : ControllerBase
  {
    private readonly finappContext _context;
    private readonly ITagService _tagService;

    public TagController(finappContext context, ITagService tagService)
    {
      _context = context;
      _tagService = tagService;
    }

    [HttpGet]
    public async Task<IEnumerable<TagModel>> Get()
    {
      var data = await _tagService.GetTags();
      return data;
    }
  }
}
