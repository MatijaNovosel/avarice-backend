using avarice_backend.Repositories.Base;
using avarice_backend.Repositories.Interfaces;
using avarice_backend.Models;
using avarice_backend.Mapper;
using avarice_backend.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avarice_backend.Repositories
{
  public class TransactionRepository : Repository<Transaction, long>, ITransactionRepository
  {
    public TransactionRepository(AvariceContext dbContext) : base(dbContext)
    {
      //
    }

    public async Task<IEnumerable<Transaction>> GetTransactionsPaginated(
      string userId,
      int? skip,
      int? take,
      string description,
      string transactionType,
      int? categoryType
    )
    {
      var spec = new TransactionWithTagsSpecification(
        userId,
        skip,
        take,
        description ?? "",
        transactionType ?? "",
        categoryType
      );
      var transactions = await GetAsync(spec);
      return transactions;
    }

    public async Task<long> GetTransactionsCount(
      string userId,
      string description,
      string transactionType,
      int? categoryType
    )
    {
      var spec = new TransactionCountSpecification(
        userId,
        description ?? "",
        transactionType ?? "",
        categoryType
      );
      var transactions = await GetAsync(spec);
      return transactions.Count;
    }
  }
}