
using Microsoft.EntityFrameworkCore;
using Product_Catalog.BLL.Interfaces;
using Product_Catalog.BLL.Specifications;
using Product_Catalog.DAL.Data;
using Product_Catalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog.BLL.Repositories
{
    public class GenericRepository<TEntity,Tkey>(StoreDbContext _dbContext) : IGenericRepository<TEntity, Tkey> where TEntity : ModelBase<Tkey>
    {
        public void Add(TEntity entity)
            => _dbContext.Add(entity);
        

        public void Delete(Tkey id)
        {
            var product = _dbContext.Set<TEntity>().Find(id);
            _dbContext.Remove(product);
        }
            
        
        public async Task<TEntity> GetByIdAsync(ISpecification<TEntity, Tkey> specification)
            =>  await SpecificationEvaluator.CreateQuery(_dbContext.Set<TEntity>(), specification).FirstOrDefaultAsync();


        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity, Tkey> specification)
        {

            return await SpecificationEvaluator.CreateQuery(_dbContext.Set<TEntity>(), specification).ToListAsync();

        }


        public void Update(TEntity entity)
        => _dbContext.Update(entity);

        public async Task<int> CountAsync(ISpecification<TEntity, Tkey> specification)
        {
            return await SpecificationEvaluator.CreateQuery(_dbContext.Set<TEntity>(), specification).CountAsync();
        }

    }
}
