using System.ComponentModel.DataAnnotations;

namespace Entities.Domain
{
    public enum AdsStatus
    {
        Active,
        Expired,
        [Display(Name = "Not start")] NotStart
    }
}