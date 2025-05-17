
using Microsoft.EntityFrameworkCore;
using Product_Catalog.BLL.Interfaces;
using Product_Catalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog.BLL.Specifications
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, Tkey>(IQueryable<TEntity> inputQuery, ISpecification<TEntity, Tkey> specification)
            where TEntity : ModelBase<Tkey>
        {
            var query = inputQuery;

            if (specification.Criteria != null)
                query = query.Where(specification.Criteria);
            query = specification.IncludeExpression.Aggregate(query,
                (currentQuery, include) => currentQuery.Include(include));

            if (specification.OrderBy != null)
                query = query.OrderBy(specification.OrderBy);
            else if (specification.OrderByDescending != null)
                query = query.OrderByDescending(specification.OrderByDescending);

            if (specification.IsPaginated)
                query = query.Skip(specification.Skip).Take(specification.Take);
            return query;

        }
    }
}
