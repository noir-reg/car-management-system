using PRN211PE_SP23_MaVanMeo.Repository.Models;

namespace PRN211PE_SP23_MaVanMeo.Repository.Repository
{
    public interface IUser
    {
        List<User> GetAllUsers();
    }
}
