using System.Threading.Tasks;
using fin_app_backend.Models;
using System.Collections.Generic;

namespace fin_app_backend.Services.Interfaces
{
  public interface ITransactionService
  {
    Task AddTransaction(AddTransactionDto transaction);
    Task AddTransfer(AddTransferDto transfer);
    Task<IEnumerable<TransactionModel>> GetAll(string userId);
  }
}