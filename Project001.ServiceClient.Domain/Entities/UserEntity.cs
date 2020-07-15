using Project001.ServiceClient.Domain.Entities.Enum;

namespace Project001.ServiceClient.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ETypeUser Type { get; set; }
    }
}
