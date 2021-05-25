using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace fin_app_backend.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TagController : ControllerBase
  {
    private readonly finappContext _context;

    public TagController(finappContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IEnumerable<TagDto> Get()
    {
      return _context.Tags.Select(x => new TagDto() { Description = x.Description, Id = x.Id, UserId = x.UserId }).ToList();
    }
  }
}
