using fin_app_backend.Entities;
using fin_app_backend.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace fin_app_backend.Specifications
{
  public sealed class TransactionWithTagsSpecification : BaseSpecification<Transaction>
  {
    public TransactionWithTagsSpecification(string userId, int skip, int take) : base(b => b.UserId == userId)
    {
      AddInclude(b => b.Transactiontags);
      AddInclude(b => b.Account);
      ApplyOrderByDescending(b => b.CreatedAt);
      ApplyPaging(skip, take);
    }
  }
}