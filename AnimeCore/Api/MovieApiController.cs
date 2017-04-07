using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace AnimeCore.Api
{
    [Produces("application/json")]
    [Route("api/Movie")]
    public class MovieApiController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Movie
        [HttpGet]
        public IActionResult GetMovies(string searchString = "")
        {
            return Ok(_unitOfWork.MovieRepository.GetAllMovieWithGenres(searchString));
        }
    }
}