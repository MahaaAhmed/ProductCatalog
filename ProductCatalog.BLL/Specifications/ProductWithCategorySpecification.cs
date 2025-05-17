
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
    public class ProductWithCategorySpecification : BaseSpecifications<Product, int>
    {
        public ProductWithCategorySpecification(int id)
            : base(p => p.Id == id && p.StartDate <= DateTime.Now && p.StartDate.AddDays(p.Duration) >= DateTime.Now)
        {
            AddIncludes(p => p.Category);
        }
        public ProductWithCategorySpecification(int id , bool flag) 
            :base(p => p.Id == id )
        {
            AddIncludes(p => p.Category);
        }
        public ProductWithCategorySpecification(ProductQueryParameters parameters)
            : base(ApplyCritria(parameters))
        {
            AddIncludes(p => p.Category);

            ApplySorting(parameters);
            ApplyPagination(parameters.PageSize, parameters.PageIndex);
        }
        public ProductWithCategorySpecification():base(null)
        {
            
        }

        private static Expression<Func<Product, bool>> ApplyCritria(ProductQueryParameters parameters)
        {
            return product =>
                        (product.StartDate <= DateTime.Now && product.StartDate.AddDays(product.Duration) >= DateTime.Now) ;
        }

        private void ApplySorting(ProductQueryParameters parameters)
        {
            switch (parameters.Options)
            {
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(p => p.Name);
                    break;
                case ProductSortingOptions.NameDesc:
                    AddOrderByDescending(p => p.Name);
                    break;
                case ProductSortingOptions.PriceAsc:
                    AddOrderBy(P => P.Price);
                    break;
                case ProductSortingOptions.PriceDesc:
                    AddOrderByDescending(P => P.Price);
                    break;
                default:
                    break;
            }
        }
    }
}
