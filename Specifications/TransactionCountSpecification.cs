using avarice_backend.Entities;
using avarice_backend.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using avarice_backend.Extensions;

namespace avarice_backend.Specifications
{
  public sealed class TransactionCountSpecification : BaseSpecification<Transaction>
  {
    public TransactionCountSpecification(
      string userId,
      string description,
      int? categoryType
    )
    {
      Expression<Func<Transaction, bool>> filterExpression = (transaction) =>
        transaction.Account.UserId == userId &&
        transaction.CategoryId == categoryType &&
        transaction.Description.ToLower().Contains(description.ToLower());

      if (categoryType != null)
      {
        Expression<Func<Transaction, bool>> expressionAddition = (t) => t.CategoryId == categoryType;
        filterExpression = PredicateBuilder.AndAlso(filterExpression, expressionAddition);
      }

      AddExpression(filterExpression);
    }
  }
}