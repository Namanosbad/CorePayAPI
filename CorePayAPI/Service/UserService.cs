using Azure.Messaging;
using CorePayAPI.Data;
using CorePayAPI.Entities;
using CorePayAPI.Repository;
using CorePayAPI.Repository.Interface;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CorePayAPI.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        // Injetando IUserRepository no UserService
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Método para consultar o usuário pelo ID
        public ApiResponse<User> ConsultUser(int userId)
        {
            ApiResponse<User> response = new(); 

            try
            {
                var user = _userRepository.Entities.SingleOrDefault(i=> i.Id == 1);

                if (user == null)
                {
                    response.Fail(404, "User not found");
                    return response;
                }

                response.Sucess(user);
            }
            catch(Exception ex)
            {
                response.Fail(500, ex.Message);
            }

            return response;
        }

    }
}
