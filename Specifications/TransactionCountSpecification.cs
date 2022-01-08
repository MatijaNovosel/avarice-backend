using fin_app_backend.Entities;
using fin_app_backend.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace fin_app_backend.Specifications
{
  public sealed class TransactionCountSpecification : BaseSpecification<Transaction>
  {
    public TransactionCountSpecification(
      string userId,
      string description,
      string transactionType
    ) : base(
      b => b.UserId == userId &&
      b.Description.ToLower().Contains(description.ToLower()) &&
      b.TransactionType.Contains(transactionType)
    )
    {
      //
    }
  }
}