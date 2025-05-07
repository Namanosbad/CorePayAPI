using CorePayAPI.Data;
using CorePayAPI.Entities;
using CorePayAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CorePayAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public DbSet<User> Entities
            => _dataContext.Set<User>();

        public async Task<decimal> ConsultUser(int userId)
        {
            return await _dataContext.Users.Where(u => u.Name == "name")
                                           .Select(i=> i.Balance).FirstOrDefaultAsync();
        }
    }
}
