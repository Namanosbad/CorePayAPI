using CorePayAPI.Data;
using CorePayAPI.Entities;
using CorePayAPI.Repository.Interface;

namespace CorePayAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

    
        public User ConsultUser(int userId)
        {
            return _dataContext.Users.SingleOrDefault(u => u.UserId == userId);
        }
    }
}
