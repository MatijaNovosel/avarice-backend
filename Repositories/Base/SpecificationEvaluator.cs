using avarice_backend.Entities;
using avarice_backend.Entities.Base;
using avarice_backend.Specifications.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace avarice_backend.Repositories.Base
{
  public class SpecificationEvaluator<EntityType, EntityBaseType> where EntityType : EntityBase<EntityBaseType>
  {
    public static IQueryable<EntityType> GetQuery(IQueryable<EntityType> inputQuery, ISpecification<EntityType> specification)
    {
      var query = inputQuery;

      if (specification.Criteria != null)
      {
        query = query.Where(specification.Criteria);
      }

      query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
      query = specification.IncludeStrings.Aggregate(query, (current, include) => current.Include(include));

      if (specification.OrderBy != null)
      {
        query = query.OrderBy(specification.OrderBy);
      }
      else if (specification.OrderByDescending != null)
      {
        query = query.OrderByDescending(specification.OrderByDescending);
      }

      if (specification.isPagingEnabled)
      {
        query = query.Skip(specification.Skip).Take(specification.Take);
      }

      return query;
    }
  }
}