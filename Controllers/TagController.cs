using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using fin_app_backend.Repositories.Interfaces;

namespace fin_app_backend.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TagController : ControllerBase
  {
    private readonly finappContext _context;
    private readonly ITagRepository _repo;

    public TagController(finappContext context, ITagRepository repo)
    {
      _context = context;
      _repo = repo;
    }

    [HttpGet]
    public async Task<IEnumerable<Tag>> Get()
    {
      var data = await _repo.GetTagListAsync();
      return data;
    }
  }
}
