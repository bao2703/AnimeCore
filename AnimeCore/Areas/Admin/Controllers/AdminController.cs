using AnimeCore.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace AnimeCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CustomAuthorize]
    public abstract class AdminController : Controller
    {
    }
}