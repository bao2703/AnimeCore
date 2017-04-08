using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace AnimeCore.Api
{
    [Produces("application/json")]
    [Route("api/Movie")]
    public class MovieApiController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MovieApiController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // GET: api/Movie
        [HttpGet]
        public IActionResult GetMovies(string searchString = "")
        {
            return Ok(_movieRepository.FindByNameContains(searchString));
        }
    }
}