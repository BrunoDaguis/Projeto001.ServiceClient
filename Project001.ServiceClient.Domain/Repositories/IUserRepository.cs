using Project001.ServiceClient.Domain.Entities;
using System.Threading.Tasks;

namespace Project001.ServiceClient.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> GetAsync(string email, string password);
    }
}
