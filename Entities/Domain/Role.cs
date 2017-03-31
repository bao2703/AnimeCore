using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Entities.Domain
{
    public class Role : IdentityRole
    {
        public string Description { get; set; }
    }
}