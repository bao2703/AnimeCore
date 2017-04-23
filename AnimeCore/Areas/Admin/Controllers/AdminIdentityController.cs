using AnimeCore.Common;
using AnimeCore.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace AnimeCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CustomAuthorize]
    public abstract class AdminIdentityController : IdentityController
    {
    }
}