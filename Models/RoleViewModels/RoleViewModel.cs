using System.ComponentModel.DataAnnotations;

namespace Models.RoleViewModels
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Role name")]
        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberOfUsers { get; set; }
    }
}