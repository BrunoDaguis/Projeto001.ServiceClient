namespace Project001.ServiceClient.Domain.Entities
{
    public class BaseEntity
    {
        public bool IsNull()
        {
            return this == null;
        }
    }
}
