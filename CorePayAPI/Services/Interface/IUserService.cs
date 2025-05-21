using CorePayAPI.Entities.CorePayDB;

namespace CorePayAPI.Services.Interface
{
    public interface IUserService
    {
        User ConsultUser(int userId);
    }
}
