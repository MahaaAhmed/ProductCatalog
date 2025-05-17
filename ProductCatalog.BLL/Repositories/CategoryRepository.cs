using Product_Catalog.BLL.Interfaces;
using Product_Catalog.DAL.Data;
using Product_Catalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog.BLL.Repositories
{
    public class CategoryRepository(StoreDbContext _dbContext) : GenericRepository<Category, int>(_dbContext)
    {
       
    }
}
