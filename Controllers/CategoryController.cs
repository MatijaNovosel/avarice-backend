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
  [Route("api/category")]
  public class CategoryController : ControllerBase
  {
    private readonly finappContext _context;
    private readonly ICategoryService _categoryService;

    public CategoryController(finappContext context, ICategoryService categoryService)
    {
      _context = context;
      _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IEnumerable<CategoryModel>> GetUserCategories()
    {
      var data = await _categoryService.GetAll(((ClaimsIdentity)User.Identity).FindFirst("Id").Value);
      return data;
    }

    [HttpPost]
    public async Task Create(CreateCategoryModel newCategory)
    {
      await _categoryService.Create(newCategory);
    }
  }
}
