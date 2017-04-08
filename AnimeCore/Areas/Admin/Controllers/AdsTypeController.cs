using System.Linq;
using System.Threading.Tasks;
using AnimeCore.Common;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Models.EpisodeViewModels;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class AdsTypeController : AdminController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdsTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}