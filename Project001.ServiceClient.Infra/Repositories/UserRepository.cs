using Microsoft.EntityFrameworkCore;
using Project001.ServiceClient.Domain.Entities;
using Project001.ServiceClient.Domain.Queries;
using Project001.ServiceClient.Domain.Repositories;
using Project001.ServiceClient.Infra.EntityFramework;
using System.Threading.Tasks;

namespace Project001.ServiceClient.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> GetAsync(string email, string password)
        {
            return await _context.User.FirstOrDefaultAsync(UserQuery.Get(email, password));
        }
    }
}
