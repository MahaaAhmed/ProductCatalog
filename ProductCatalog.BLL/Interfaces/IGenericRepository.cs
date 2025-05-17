
using Product_Catalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog.BLL.Interfaces
{
    public interface IGenericRepository<TEntity,Tkey> where TEntity : ModelBase<Tkey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity, Tkey> specification);
        Task<TEntity> GetByIdAsync(ISpecification<TEntity, Tkey> specification);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(Tkey id);
        Task<int> CountAsync(ISpecification<TEntity, Tkey> specification);
    }
}
