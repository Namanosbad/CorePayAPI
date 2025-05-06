using CorePayAPI.Entities;

namespace CorePayAPI.Service
{
    public interface IUserService
    {
        User ConsultUser(int userId);
    }
}
