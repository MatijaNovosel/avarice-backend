using System.Threading.Tasks;
using fin_app_backend.Models;

namespace fin_app_backend.Services.Interfaces
{
  public interface ITransactionService
  {
    Task<int> AddTransaction(TransactionModel transaction);
  }
}