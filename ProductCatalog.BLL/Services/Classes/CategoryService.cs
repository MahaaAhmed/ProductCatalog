using AutoMapper;
using Product_Catalog.BLL.Dtos;
using Product_Catalog.BLL.Interfaces;
using Product_Catalog.BLL.Services.Interfacies;
using Product_Catalog.BLL.Specifications;
using Product_Catalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog.BLL.Services.Classes
{
    public class CategoryService(IUnitOfwork _unitOfWork) : ICategoryService
    {
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            var specifications = new CategorySpecifications();
            var categories =await _unitOfWork.CategoryRepository.GetAllAsync(specifications);
           
            return categories;
        }
    }
}
