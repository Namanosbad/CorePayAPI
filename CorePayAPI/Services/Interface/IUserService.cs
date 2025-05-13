using CorePayAPI.Entities.CorePayDB;

namespace CorePayAPI.Service.Interface
{
    public interface IUserService
    {
        User ConsultUser(int userId);
    }
}
