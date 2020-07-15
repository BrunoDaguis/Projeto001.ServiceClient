using Newtonsoft.Json;
using Project001.ServiceClient.Domain.Entities.Enum;

namespace Project001.ServiceClient.Api.Model
{
    public class UserModel
    {
        public UserModel(string email, string name, ETypeUser type)
        {
            Email = email;
            Name = name;
            Type = type;
        }

        public string Email { get; set; }
        public string Name { get; set; }
        public ETypeUser Type { get; set; }
    }
}
