using avarice_backend.Extensions;
using avarice_backend.Specifications.Base;
using System;
using System.Linq.Expressions;

namespace avarice_backend.Specifications
{
  public sealed class TransactionWithTagsSpecification : BaseSpecification<Transaction>
  {
    public TransactionWithTagsSpecification(
      string userId,
      int? skip,
      int? take,
      string description,
      int? categoryType
    )
    {
      Expression<Func<Transaction, bool>> filterExpression = (transaction) =>
        transaction.Account.UserId == userId &&
        transaction.Description.ToLower().Contains(description.ToLower());

      if (categoryType != null)
      {
        Expression<Func<Transaction, bool>> expressionAddition = (t) => t.CategoryId == categoryType;
        filterExpression = PredicateBuilder.AndAlso(filterExpression, expressionAddition);
      }

      AddExpression(filterExpression);

      AddInclude(b => b.Account);
      AddInclude(b => b.Category);
      AddInclude(b => b.Category.Parent);
      ApplyOrderByDescending(b => b.CreatedAt);

      if (skip != null && take != null)
      {
        ApplyPaging((int)skip, (int)take);
      }
    }
  }
}