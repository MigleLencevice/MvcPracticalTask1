using Microsoft.AspNetCore.Mvc;
using MovieService.Security;

namespace MovieService.Controllers
{
    [ApiKeyAuth]
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly Services.MovieService _movieService;

        public MoviesController(Services.MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = _movieService.GetMovies();

            return Ok(movies);
        }
    }
}