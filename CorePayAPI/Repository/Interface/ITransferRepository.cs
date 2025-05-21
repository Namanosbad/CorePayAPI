using CorePayAPI.DTOs.Requests;
using CorePayAPI.Entities.CorePayDB;
using System.Transactions;

namespace CorePayAPI.Repository.Interface
{
    public interface ITransferRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task SaveChangesAsync();
    }
}