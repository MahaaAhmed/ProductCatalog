using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Product_Catalog.BLL.Repositories;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Service.Services
{
    public class ProductService(IUnitOfwork _unitOfWork, IMapper _mapper) : IProductService
    {
       

        public async Task<PaginationResponse<ProductDto>> GetAllProductsAsync(ProductQueryParameters parameters)
        {
            var specifications = new ProductWithCategorySpecification(parameters);
            var products = await _unitOfWork.ProductRepository.
            var Data = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
            var ProductCount = products.Count();
            var countSpec = new ProductCountSpecifications(parameters);
            var totalCount = await Repo.CountAsync(countSpec);
            return new PaginationResponse<ProductDto>(parameters.PageIndex, ProductCount, totalCount, Data);
        }


        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var specifications = new ProductCategorySpecification(id);
            var product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(specifications);
            if (product is null)
            {
                throw new ProductNotFoundException(id);
            }

            return _mapper.Map<Product, ProductDto>(product);
        }
    }
}
