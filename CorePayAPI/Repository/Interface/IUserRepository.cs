using CorePayAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CorePayAPI.Repository.Interface
{
    public interface IUserRepository
    {
        Task<decimal> ConsultUser(int UserId);
        DbSet<User> Entities { get; }
    }
}
