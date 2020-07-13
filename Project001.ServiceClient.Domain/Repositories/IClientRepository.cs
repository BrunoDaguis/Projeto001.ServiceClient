using Project001.ServiceClient.Domain.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project001.ServiceClient.Domain.Repositories
{
    public interface IClientRepository
    {
        Task CreateAsync(ClientEntity entity);
        Task UpdateAsync(ClientEntity entity);
        Task<ClientEntity> GetAsync(int id);
        Task<IEnumerable<ClientEntity>> GetPendingAsync();
        Task<IEnumerable<ClientEntity>> GetApprovedAsync();
        Task<IEnumerable<ClientEntity>> GetRepprovedAsync();
        Task DeleteAsync(ClientEntity entity);
    }
}
