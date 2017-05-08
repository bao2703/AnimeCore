using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class SettingViewModel
    {
        [Display(Name = "Page size")]
        public int PageSize { get; set; }

        [Display(Name = "Facebook App Id")]
        public string FacebookAppId { get; set; }

        [Display(Name = "Facebook App Secret")]
        public string FacebookAppSecret { get; set; }
    }
}