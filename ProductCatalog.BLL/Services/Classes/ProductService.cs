using AutoMapper;

using Product_Catalog.BLL.Dtos;
using Product_Catalog.BLL.Interfaces;
using Product_Catalog.BLL.Repositories;
using Product_Catalog.BLL.Services.Interfacies;
using Product_Catalog.BLL.Specifications;
using Product_Catalog.DAL.Exceptions;
using Product_Catalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog.BLL.Services.Classes
{
    public class ProductService(IUnitOfwork _unitOfWork, IMapper _mapper) : IProductService
    {


        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(ProductQueryParameters parameters)
        {
            var specifications = new ProductWithCategorySpecification(parameters);
            var products = await _unitOfWork.ProductRepository.GetAllAsync(specifications);
            var Data = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
            var ProductCount = products.Count();
            var countSpec = new ProductCountSpecifications(parameters);
            var totalCount = await _unitOfWork.ProductRepository.CountAsync(countSpec);
            return Data;
        }
        public async Task<IEnumerable<ProductDto>> GetAllProductsAsyncForAdmin()
        {
            var specifications = new ProductWithCategorySpecification();
            var products = await _unitOfWork.ProductRepository.GetAllAsync(specifications);
            var Data = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
            ;
            return Data;
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var specifications = new ProductWithCategorySpecification(id);
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(specifications);
            if (product is null)
            {
                throw new ProductNotFoundException(id);
            }

            return _mapper.Map<Product, ProductDto>(product);
        }
        public async Task<ProductDto> GetProductByIdAsyncForAdmin(int id)
        {
            var specifications = new ProductWithCategorySpecification(id , false);
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(specifications);
            if (product is null)
            {
                throw new ProductNotFoundException(id);
            }

            return _mapper.Map<Product, ProductDto>(product);
        }
        public IEnumerable<ProductDto> SearchProductByName(string name)
        {
            var Products = _unitOfWork.ProductRepository.SearchByName(name.ToLower());
          
            var returnedProducts = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(Products); // Auto Mapper

            return returnedProducts;
        }

        public int CreateProduct(ProductDto productDto)
        {
            var Product = _mapper.Map<ProductDto, Product>(productDto);

            _unitOfWork.ProductRepository.Add(Product);

            return _unitOfWork.SaveChanges();
        }

        public bool DeleteProduct(int id) 
        {
            var flag = false; 
            if(id!= 0 )
            {
                _unitOfWork.ProductRepository.Delete(id);
                _unitOfWork.SaveChanges();
                flag = true;
            }
            return flag;
        }

        public int UpdateProduct(ProductDto productDto)
        {
            _unitOfWork.ProductRepository.Update(_mapper.Map<ProductDto, Product>(productDto));


            return _unitOfWork.SaveChanges();
        }

    }
}
