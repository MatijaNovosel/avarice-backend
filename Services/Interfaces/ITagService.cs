using avarice_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace avarice_backend.Services.Interfaces
{
  public interface ITagService
  {
    Task<IEnumerable<TagModel>> GetTags(string userId);
  }
}