

using Product_Catalog.BLL.Interfaces;
using Product_Catalog.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog.BLL.Repositories
{
    public class UnitOfWork : IUnitOfwork
    {
        private Lazy<IProductRepository> _ProductRepository;
        private Lazy<CategoryRepository> _CategoryRepository;

        private readonly StoreDbContext _dbContext;

        public UnitOfWork(StoreDbContext dbContext)
        {
            _ProductRepository = new Lazy<IProductRepository>(() => new ProductRepository(dbContext));
            _CategoryRepository = new Lazy<CategoryRepository>(() => new CategoryRepository(dbContext));
            _dbContext = dbContext;
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _ProductRepository.Value;
            }


        }
        public CategoryRepository CategoryRepository
        {
            get
            {
                return _CategoryRepository.Value;
            }


        }
        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

    }
}
