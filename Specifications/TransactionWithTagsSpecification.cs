using fin_app_backend.Entities;
using fin_app_backend.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace fin_app_backend.Specifications
{
  public sealed class TransactionWithTagsSpecification : BaseSpecification<Transaction>
  {
    public TransactionWithTagsSpecification(string userId, int? skip, int? take) : base(b => b.UserId == userId)
    {
      AddInclude(b => b.Account);
      AddInclude(b => b.Category);
      ApplyOrderByDescending(b => b.Id);

      if (skip != null && take != null)
      {
        ApplyPaging((int)skip, (int)take);
      }
    }
  }
}