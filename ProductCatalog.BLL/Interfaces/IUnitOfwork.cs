
using Product_Catalog.BLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog.BLL.Interfaces
{
    public interface IUnitOfwork 
    {
        public IProductRepository ProductRepository { get; }
        public CategoryRepository CategoryRepository { get; }

        public int SaveChanges();
    }
}
