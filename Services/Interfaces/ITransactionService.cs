using System.Threading.Tasks;
using fin_app_backend.Models;
using System.Collections.Generic;

namespace fin_app_backend.Services.Interfaces
{
  public interface ITransactionService
  {
    Task AddTransaction(AddTransactionDto transaction, string userId);
    Task AddTransfer(AddTransferDto transfer, string userId);
    Task<IEnumerable<TransactionModel>> GetAll(string userId, int? skip, int? take);
    Task<long> GetCount(string userId);
  }
}