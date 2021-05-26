using System.Threading.Tasks;
using fin_app_backend.Models;

namespace fin_app_backend.Services.Interfaces
{
  public interface ITransactionService
  {
    Task AddTransaction(AddTransactionDto transaction);
    Task AddTransfer(AddTransferDto transfer);
  }
}