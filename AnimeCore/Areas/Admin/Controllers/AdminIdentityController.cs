using AnimeCore.Common;
using AnimeCore.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace AnimeCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [TypeFilter(typeof(CustomAuthorizeAttribute))]
    public abstract class AdminIdentityController : IdentityController
    {
    }
}