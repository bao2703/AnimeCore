using System.Collections.Generic;
using System.Linq;
using Entities.Domain;
using Microsoft.AspNetCore.Identity;

namespace Services
{
    public interface IUserService
    {
        List<User> ToList();
    }

    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public List<User> ToList()
        {
            return _userManager.Users.ToList();
        }
    }
}