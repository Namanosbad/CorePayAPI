using CorePayAPI.Entities;

namespace CorePayAPI.Service
{
    public interface IUserService
    {
        ApiResponse<User> ConsultUser(int userId);
    }
}
