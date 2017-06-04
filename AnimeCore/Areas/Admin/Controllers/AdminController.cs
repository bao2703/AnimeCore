using System;
using System.Threading.Tasks;
using AnimeCore.Common;
using AnimeCore.Configuration;
using Entities.Domain;
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
            var filePath = Constant.ImagesFolderPath + $"/{DateTime.Now.ToFileTime()}{file.FileName}";
            await Helper.CopyFileToAsync(filePath, file);
            return filePath;
        }

        protected async Task UpdateFileIfExistAsync(Advertisement advertisement, IFormFile file)
        {
            if (file != null)
            {
                advertisement.Source = await UploadAsync(file);
            }
        }
    }
}