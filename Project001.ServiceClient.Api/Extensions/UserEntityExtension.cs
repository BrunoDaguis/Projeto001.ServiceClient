using Project001.ServiceClient.Api.Model;
using Project001.ServiceClient.Domain.Entities;

namespace Project001.ServiceClient.Api.Extensions
{
    public static class UserEntityExtension
    {
        public static UserModel ToModel(this UserEntity entity)
        {
            return new UserModel(entity.Email, entity.Name, entity.Type);
        }
    }
}
