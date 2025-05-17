
using Product_Catalog.BLL.Repositories;
using Product_Catalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog.BLL.Specifications
{
    public class ProductCountSpecifications : BaseSpecifications<Product, int>
    {
        public ProductCountSpecifications(ProductQueryParameters parameters) : base(ApplyCritria(parameters))
        {

        }
        private static Expression<Func<Product, bool>> ApplyCritria(ProductQueryParameters parameters)
        {
            return product =>
                        (!parameters.CategoryId.HasValue || product.CategoryId == parameters.CategoryId.Value) &&
                        (string.IsNullOrEmpty(parameters.Search) ||
                        product.Name.ToLower().Contains(parameters.Search.ToLower()));
        }
    }
}
