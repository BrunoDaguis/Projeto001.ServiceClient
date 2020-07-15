using Project001.ServiceClient.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Project001.ServiceClient.Domain.Queries
{
    public static class UserQuery
    {
        public static Expression<Func<UserEntity, bool>> Get(string email, string password)
        {
            return x => x.Email == email && x.Password == password;
        }
    }
}
