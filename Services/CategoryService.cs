using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using avarice_backend.Services.Interfaces;
using avarice_backend.Repositories.Interfaces;
using avarice_backend.Models;
using avarice_backend.Mapper;
using avarice_backend.Utils;
using System.Linq;

namespace avarice_backend.Services
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

    public async Task Create(CreateCategoryModel newCategory, string userId)
    {
      await _categoryRepository.AddAsync(new Category
      {
        Color = newCategory.Color,
        Icon = newCategory.Icon,
        Name = newCategory.Name,
        ParentId = newCategory.ParentId,
        UserId = userId,
        System = false
      });
    }
  }
}