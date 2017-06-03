using System;
using System.Threading.Tasks;
using AnimeCore.Common;
using AnimeCore.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [TypeFilter(typeof(CustomAuthorizeAttribute))]
    public abstract class AdminController : Controller
    {
        protected async Task<string> UploadAsync(IFormFile file)
        {
            var filePath = Constant.ImagesFolderPath + DateTime.Now.ToFileTime() + file.FileName;
            await Helper.CopyFileToAsync(filePath, file);
            return filePath;
        }
    }
}