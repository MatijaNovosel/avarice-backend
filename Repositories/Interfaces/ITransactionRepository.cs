using avarice_backend.Entities;
using avarice_backend.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using avarice_backend.Models;

namespace avarice_backend.Repositories.Interfaces
{
  public interface ITransactionRepository : IRepository<Transaction>
  {
    Task<IEnumerable<Transaction>> GetTransactionsPaginated(
      string userId,
      int? skip,
      int? take,
      string description,
      string transactionType,
      int? categoryType
    );
    Task<long> GetTransactionsCount(
      string userId,
      string description,
      string transactionType,
      int? categoryType
    );
  }
}