using CorePay.API.Domain.Entities;

namespace CorePayAPI.Repository.Interface
{
    public interface ITransferRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task SaveChangesAsync();
    }
}