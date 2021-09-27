using fin_app_backend.Entities;
using fin_app_backend.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using fin_app_backend.Models;

namespace fin_app_backend.Repositories.Interfaces
{
  public interface ITransactionRepository : IRepository<Transaction>
  {
    Task<IEnumerable<Transaction>> GetTransactionsPaginated(string userId, int? skip, int? take, string description);
  }
}