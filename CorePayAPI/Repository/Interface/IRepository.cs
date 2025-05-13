using CorePayAPI.Data;
using CorePayAPI.Entities.Interface;
using Microsoft.EntityFrameworkCore;

namespace CorePayAPI.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        DbSet<TEntity> Entities {get; }

        Task<List<TEntity>> GetAsync();

        Task<TEntity?> GetByIdAsync(int id);

        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> DeleteAsync(int id);

        Task<bool> AnyAsync(int id);
    }
}
