using CorePayAPI.Entities.CorePayDB;

namespace CorePayAPI.Repository.Interface
{
    public interface IUserRepository
    {
        User ConsultUser(int UserId);

    }
}
