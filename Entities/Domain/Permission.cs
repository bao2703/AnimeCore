namespace Entities.Domain
{
    public class Permission : Entity
    {
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public string Description { get; set; }
    }
}