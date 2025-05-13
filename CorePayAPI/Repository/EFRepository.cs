using CorePayAPI.Data;
using CorePayAPI.Entities.Interface;
using CorePayAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CorePayAPI.Repository
{
    public class EFRepository<TEntity>(CorePayDb corePayDbContext) : IRepository<TEntity>
     where TEntity : class, IEntity

    {
        protected readonly CorePayDb _corePaydbContext = corePayDbContext;

        public DbSet<TEntity> Entities
           => _corePaydbContext.Set<TEntity>();

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _corePaydbContext.Set<TEntity>()
                            .AddAsync(entity);

            await _corePaydbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _corePaydbContext.AddRangeAsync(entities);
            await _corePaydbContext.SaveChangesAsync();

            return entities;
        }

        public async Task<TEntity> DeleteAsync(int id)
        {
            var current = await _corePaydbContext.Set<TEntity>()
                                          .SingleAsync(i => i.Id == id);

            _corePaydbContext.Set<TEntity>().Remove(current);

            await _corePaydbContext.SaveChangesAsync();

            return current;
        }

        public Task<List<TEntity>> GetAsync()
          => _corePaydbContext.Set<TEntity>()
                       .AsNoTracking()
                       .ToListAsync();

        public Task<TEntity?> GetByIdAsync(int id)
    => _corePaydbContext.Set<TEntity>()
                 .AsNoTracking()
                 .FirstOrDefaultAsync(i => i.Id == id);

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var current = await _corePaydbContext.Set<TEntity>()
                                          .SingleAsync(i => i.Id == entity.Id);

            _corePaydbContext.Entry(current).CurrentValues.SetValues(entity);

            _corePaydbContext.Set<TEntity>().Update(current);

            await _corePaydbContext.SaveChangesAsync();

            return current;

        }

        public Task<bool> AnyAsync(int id)
       => _corePaydbContext.Set<TEntity>()
                    .AnyAsync(i => i.Id == id);
    }
}
