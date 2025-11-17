using CorePay.API.Domain.Entities;

namespace CorePayAPI.Repository.Interface
{
    public interface IUserRepository
    {
        User ConsultUser(int UserId);

    }
}
