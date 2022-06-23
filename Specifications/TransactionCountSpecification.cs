using fin_app_backend.Entities;
using fin_app_backend.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using fin_app_backend.Extensions;

namespace fin_app_backend.Specifications
{
  public sealed class TransactionCountSpecification : BaseSpecification<Transaction>
  {
    public TransactionCountSpecification(
      string userId,
      string description,
      string transactionType,
      int? categoryType
    )
    {
      Expression<Func<Transaction, bool>> filterExpression = (transaction) =>
        transaction.UserId == userId &&
        transaction.Description.ToLower().Contains(description.ToLower()) &&
        transaction.TransactionType.Contains(transactionType);

      if (categoryType != null)
      {
        Expression<Func<Transaction, bool>> expressionAddition = (t) => t.CategoryId == categoryType;
        filterExpression = PredicateBuilder.AndAlso(filterExpression, expressionAddition);
      }

      AddExpression(filterExpression);
    }
  }
}