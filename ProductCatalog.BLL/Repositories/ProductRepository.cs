
using Product_Catalog.BLL.Interfaces;
using Product_Catalog.DAL.Data;
using Product_Catalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog.BLL.Repositories
{
    public class ProductRepository(StoreDbContext _dbContext) : GenericRepository<Product,int>(_dbContext), IProductRepository
    {
        public IQueryable<Product> SearchByName(string name)
        {
            return _dbContext.Products.Where(E => E.Name.ToLower().Contains(name));
        }
    }
}
