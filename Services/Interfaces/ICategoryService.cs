using System.Threading.Tasks;
using avarice_backend.Models;
using System.Collections.Generic;

namespace avarice_backend.Services.Interfaces
{
  public interface ICategoryService
  {
    Task<IEnumerable<CategoryModel>> GetAll(string userId);
    Task Create(CreateCategoryModel newCategory, string userId);
  }
}