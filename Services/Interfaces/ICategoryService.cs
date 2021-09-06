using System.Threading.Tasks;
using fin_app_backend.Models;
using System.Collections.Generic;

namespace fin_app_backend.Services.Interfaces
{
  public interface ICategoryService
  {
    Task<IEnumerable<CategoryModel>> GetAll(string userId);
    Task Create(CreateCategoryModel newCategory, string userId);
  }
}