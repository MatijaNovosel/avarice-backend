using fin_app_backend.Repositories.Base;
using fin_app_backend.Repositories.Interfaces;
using fin_app_backend.Models;
using fin_app_backend.Mapper;
using fin_app_backend.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fin_app_backend.Repositories
{
  public class TransactionRepository : Repository<Transaction>, ITransactionRepository
  {
    public TransactionRepository(finappContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Transaction>> GetTransactionsPaginated(string userId)
    {
      var spec = new TransactionWithTagsSpecification(userId);
      var transactions = await GetAsync(spec);
      return transactions;
    }
  }
}