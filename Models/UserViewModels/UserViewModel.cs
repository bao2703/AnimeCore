using System.ComponentModel.DataAnnotations;

namespace Models.UserViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Role")]
        public string RoleId { get; set; }
    }
}