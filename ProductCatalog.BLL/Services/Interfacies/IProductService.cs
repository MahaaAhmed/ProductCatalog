using Product_Catalog.BLL.Dtos;
using Product_Catalog.BLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog.BLL.Services.Interfacies
{
    public interface IProductService
    {

        Task<IEnumerable<ProductDto>> GetAllProductsAsync(ProductQueryParameters queryParameters);
        Task<IEnumerable<ProductDto>> GetAllProductsAsyncForAdmin();


        Task<ProductDto> GetProductByIdAsync(int id);
        Task<ProductDto> GetProductByIdAsyncForAdmin(int id);

        IEnumerable<ProductDto> SearchProductByName(string name);
        int CreateProduct(ProductDto product);
        int UpdateProduct(ProductDto product);
        bool DeleteProduct(int id);

    }
}
