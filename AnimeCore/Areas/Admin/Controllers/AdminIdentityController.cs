using AnimeCore.Common;
using Microsoft.AspNetCore.Mvc;

namespace AnimeCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public abstract class AdminIdentityController : IdentityController
    {
    }
}