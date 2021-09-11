using System.Threading.Tasks;
using fin_app_backend.Models;
using System.Collections.Generic;

namespace fin_app_backend.Services.Interfaces
{
  public interface ITemplateService
  {
    Task AddTemplate(AddTemplateDto template, string userId);
    Task DeleteTemplate(string userId, long templateId);
    Task<IEnumerable<TemplateModel>> GetAll(string userId);
    Task<long> GetCount(string userId);
  }
}