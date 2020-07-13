using Project001.ServiceClient.Domain.Entities;
using Project001.ServiceClient.Domain.Entities.Enum;
using System;
using System.Linq.Expressions;

namespace Project001.ServiceClient.Domain.Queries
{
    public static class ClientQuery
    {
        public static Expression<Func<ClientEntity, bool>> Get(int id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<ClientEntity, bool>> GetPendings()
        {
            return x => x.Status == EStatusClient.Pending;
        }
        public static Expression<Func<ClientEntity, bool>> GetApproveds()
        {
            return x => x.Status == EStatusClient.Approved;
        }
        public static Expression<Func<ClientEntity, bool>> GetRepproveds()
        {
            return x => x.Status == EStatusClient.Repproved;
        }
    }
}
