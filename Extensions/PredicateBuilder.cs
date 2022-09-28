using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace avarice_backend.Extensions
{
  internal class SubstExpressionVisitor : System.Linq.Expressions.ExpressionVisitor
  {
    public Dictionary<Expression, Expression> subst = new Dictionary<Expression, Expression>();

    protected override Expression VisitParameter(ParameterExpression node)
    {
      Expression newValue;
      if (subst.TryGetValue(node, out newValue))
      {
        return newValue;
      }
      return node;
    }
  }

  public static class PredicateBuilder
  {

    public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> a, Expression<Func<T, bool>> b)
    {

      ParameterExpression p = a.Parameters[0];

      SubstExpressionVisitor visitor = new SubstExpressionVisitor();
      visitor.subst[b.Parameters[0]] = p;

      Expression body = Expression.AndAlso(a.Body, visitor.Visit(b.Body));
      return Expression.Lambda<Func<T, bool>>(body, p);
    }

    public static Expression<Func<T, bool>> OrAlso<T>(this Expression<Func<T, bool>> a, Expression<Func<T, bool>> b)
    {

      ParameterExpression p = a.Parameters[0];

      SubstExpressionVisitor visitor = new SubstExpressionVisitor();
      visitor.subst[b.Parameters[0]] = p;

      Expression body = Expression.OrElse(a.Body, visitor.Visit(b.Body));
      return Expression.Lambda<Func<T, bool>>(body, p);
    }
  }
}