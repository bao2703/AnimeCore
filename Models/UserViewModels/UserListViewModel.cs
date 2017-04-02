using System.ComponentModel.DataAnnotations;

namespace Models.UserViewModels
{
    public class UserListViewModel : UserViewModel
    {
        [Display(Name = "Email confirmed")]
        public bool EmailConfirmed { get; set; }
    }
}