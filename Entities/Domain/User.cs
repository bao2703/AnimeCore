using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Entities.Domain
{
    public class User : IdentityUser
    {
        public ICollection<Like> Likes { get; set; }
    }
}