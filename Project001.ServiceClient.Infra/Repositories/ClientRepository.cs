using Microsoft.EntityFrameworkCore;
using Project001.ServiceClient.Domain.Entities;
using Project001.ServiceClient.Domain.Queries;
using Project001.ServiceClient.Domain.Repositories;
using Project001.ServiceClient.Infra.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project001.ServiceClient.Infra.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DatabaseContext _context;

        public ClientRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(ClientEntity entity)
        {
            _context.Client.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ClientEntity entity)
        {
            _context.Client.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClientEntity>> GetApprovedAsync()
        {
            return await _context.Client.AsNoTracking().Where(ClientQuery.GetApproveds()).ToListAsync();
        }

        public async Task<ClientEntity> GetAsync(int id)
        {
            return await _context.Client.AsNoTracking().FirstOrDefaultAsync(ClientQuery.Get(id));
        }

        public async Task<IEnumerable<ClientEntity>> GetPendingAsync()
        {
            return await _context.Client.AsNoTracking().Where(ClientQuery.GetPendings()).ToListAsync();
        }

        public async Task<IEnumerable<ClientEntity>> GetRepprovedAsync()
        {
            return await _context.Client.AsNoTracking().Where(ClientQuery.GetRepproveds()).ToListAsync();
        }

        public async Task UpdateAsync(ClientEntity entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
