
using Product_Catalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog.BLL.Interfaces
{
    public interface ISpecification<TEntity, T> where TEntity : ModelBase<T>
    {
        Expression<Func<TEntity, bool>>? Criteria { get; } 
        List<Expression<Func<TEntity, object>>> IncludeExpression { get; }
        Expression<Func<TEntity, object>> OrderBy { get; } 
        Expression<Func<TEntity, object>> OrderByDescending { get; }
        int Skip { get; }
        int Take { get; }
        bool IsPaginated { get; }

    }
}
