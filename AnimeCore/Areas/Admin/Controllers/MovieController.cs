using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class MovieController : AdminController
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MovieController(IUnitOfWork unitOfWork, IMovieRepository movieRepository)
        {
            _unitOfWork = unitOfWork;
            _movieRepository = movieRepository;
        }

        public IActionResult Index()
        {
            var model = _movieRepository.GetAll();
            return View(model);
        }
    }
}