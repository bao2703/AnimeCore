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
        public string Email { get; set; }
    }
}