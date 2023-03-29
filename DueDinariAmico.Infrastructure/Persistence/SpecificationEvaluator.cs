using DueDinariAmico.Application.Specifications;
using Microsoft.EntityFrameworkCore;

namespace DueDinariAmico.Infrastructure.Persistence;

public class SpecificationEvaluator<T> where T : class
{
    public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, Specification<T> specification)
    {
        IQueryable<T> query = inputQuery;

        // modify the IQueryable using the specification's criteria expression
        if (specification.Criteria is not null)
        {
            query = query.Where(specification.Criteria);
        }

        // Includes all expression-based includes
        query = specification.Includes.Aggregate(query,
            (current, include) => current.Include(include));

        // Apply ordering if expressions are set
        if (specification.OrderBy != null)
        {
            query = query.OrderBy(specification.OrderBy);
        }
        else if (specification.OrderByDescending != null)
        {
            query = query.OrderByDescending(specification.OrderByDescending);
        }
            
        return query;
    }
}
