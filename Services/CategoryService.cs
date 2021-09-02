using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using fin_app_backend.Services.Interfaces;
using fin_app_backend.Repositories.Interfaces;
using fin_app_backend.Models;
using fin_app_backend.Mapper;
using fin_app_backend.Utils;
using System.Linq;

namespace fin_app_backend.Services
{
  public class CategoryService : ICategoryService
  {
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
      _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    }

    public async Task<IEnumerable<CategoryModel>> GetAll(string userId)
    {
      var categories = await _categoryRepository.GetAsync(x => x.UserId == userId && x.System == false);
      var mapped = ObjectMapper.Mapper.Map<IEnumerable<CategoryModel>>(categories);
      return mapped;
    }

    public async Task Create(CreateCategoryModel newCategory)
    {
      await _categoryRepository.AddAsync(new Category
      {
        Color = newCategory.Color,
        Icon = newCategory.Icon,
        Name = newCategory.Name,
        UserId = newCategory.UserId,
        System = false
      });
    }
  }
}