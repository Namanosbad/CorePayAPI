using CorePay.API.Application.Interfaces;
using CorePay.API.Domain.Entities;
using CorePayAPI.Repository.Interface;

namespace CorePayAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User ConsultUser(int userId)
        {
            var user = _userRepository.ConsultUser(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            return user;
        }

    }
}
