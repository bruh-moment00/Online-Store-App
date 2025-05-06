using Online_Store_Backend.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Backend.Core.Data.Repository
{
    public interface IRepositoryAsync<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> FindById(long id);
        Task<long> Insert(TEntity entity);
        Task<long> Update(TEntity entity);
        Task<bool> Delete(long id);
        Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate);
    }
}
