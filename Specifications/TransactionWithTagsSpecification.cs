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
      string transactionType,
      int? categoryType
    )
    {
      Expression<Func<Transaction, bool>> expression = (transaction) =>
        transaction.UserId == userId &&
        transaction.Description.ToLower().Contains(description.ToLower()) &&
        transaction.TransactionType.Contains(transactionType);

      AddExpression(expression);

      AddInclude(b => b.Account);
      AddInclude(b => b.Category);
      AddInclude(b => b.Category.Parent);
      ApplyOrderByDescending(b => b.Id);

      if (skip != null && take != null)
      {
        ApplyPaging((int)skip, (int)take);
      }
    }
  }
}