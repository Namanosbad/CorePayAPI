using Azure.Messaging;
using CorePayAPI.Data;
using CorePayAPI.Entities.CorePayDB;
using CorePayAPI.Repository;
using CorePayAPI.Repository.Interface;
using CorePayAPI.Service.Interface;
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
        public User ConsultUser(int userId)
        {
            var user = _userRepository.ConsultUser(userId); // Consultando o repositório
            if (user == null)
            {
                throw new Exception("Usuário não encontrado.");
            }
            return user; // Retornando o usuário encontrado
        }

    }
}
