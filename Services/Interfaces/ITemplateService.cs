using System.Threading.Tasks;
using avarice_backend.Models;
using System.Collections.Generic;

namespace avarice_backend.Services.Interfaces
{
  public interface ITemplateService
  {
    Task AddTemplate(AddTemplateDto template, string userId);
    Task DeleteTemplate(string userId, long templateId);
    Task<IEnumerable<TemplateModel>> GetAll(string userId);
    Task<long> GetCount(string userId);
  }
}