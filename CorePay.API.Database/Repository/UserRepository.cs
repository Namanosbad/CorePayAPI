using CorePay.API.Domain.Entities;
using CorePayAPI.Data;
using CorePayAPI.Repository.Interface;

namespace CorePayAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CorePayDb _dataContext;

        public UserRepository(CorePayDb dataContext)
        {
            _dataContext = dataContext;
        }
        public User ConsultUser(int userId)
        {
            return _dataContext.Users.SingleOrDefault(u => u.Id == userId);
        }
    }
}
