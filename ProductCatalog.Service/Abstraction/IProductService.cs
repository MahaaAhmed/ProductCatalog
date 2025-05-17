using Product_Catalog.BLL.Repositories;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Service.Abstraction
{
    public interface IProductService
    {

        Task<PaginationResponse<ProductDto>> GetAllProductsAsync(ProductQueryParameters queryParameters);

        Task<ProductDto> GetProductByIdAsync(int id);

       
    }
}
