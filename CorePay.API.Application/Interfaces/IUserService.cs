using CorePay.API.Domain.Entities;

namespace CorePay.API.Application.Interfaces
{
    public interface IUserService
    {
        User ConsultUser(int userId);
    }
}
