using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Online_Store_Backend.Core.Entity;

namespace Online_Store_Backend.Core.Data.Repository
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext dbContext;

        public RepositoryAsync(DbContext context) => this.dbContext = context;

        public async Task<TEntity> FindById(long id) => await this.dbContext.Set<TEntity>().FindAsync(id);

        public async Task<long> Insert(TEntity entity)
        {
            await this.dbContext.Set<TEntity>().AddAsync(entity);

            await this.dbContext.SaveChangesAsync();

            return entity.ID;
        }

        public async Task<long> Update(TEntity entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;

            return await this.dbContext.SaveChangesAsync();
        }
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<bool> Delete(long id)
        {
            var entity = await this.FindById(id);

            if (entity == null)
            {
                return false;
            }

            entity.IsDeleted = true;

            this.dbContext.Entry(entity).State = EntityState.Modified;

            return await this.dbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate) => await this.dbContext.Set<TEntity>().Where(predicate).ToListAsync();
    }
}
