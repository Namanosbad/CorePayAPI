using Azure.Messaging;
using CorePayAPI.Data;
using CorePayAPI.Entities.CorePayDB;
using CorePayAPI.Repository;
using CorePayAPI.Repository.Interface;
using CorePayAPI.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;

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
