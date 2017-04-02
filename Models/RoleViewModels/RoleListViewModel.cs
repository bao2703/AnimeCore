using System.ComponentModel.DataAnnotations;

namespace Models.RoleViewModels
{
    public class RoleListViewModel : RoleViewModel
    {
        [Display(Name = "Number of users")]
        public int NumberOfUsers { get; set; }
    }
}