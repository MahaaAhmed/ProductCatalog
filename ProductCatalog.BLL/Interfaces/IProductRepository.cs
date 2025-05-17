
using Product_Catalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog.BLL.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product,int >
    {
        IQueryable<Product> SearchByName(string name);

    }
}
