using Microsoft.AspNetCore.Mvc;
using Services;

namespace AnimeCore.Api
{
    [Produces("application/json")]
    [Route("api/Movie")]
    public class MovieApiController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieApiController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/Movie
        [HttpGet]
        public IActionResult GetMovies(string searchString = "")
        {
            return Ok(_movieService.FindBy(searchString));
        }

        // GET: api/Movie/5
        [HttpGet("{id}")]
        public IActionResult GetMovie([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var movie = _movieService.FindBy(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }
    }
}