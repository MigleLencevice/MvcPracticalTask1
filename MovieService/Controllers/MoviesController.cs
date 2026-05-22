using Microsoft.AspNetCore.Mvc;
using MovieService.Models;
using System.Text.Json;

namespace MovieService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public MoviesController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        private static List<Movie> movies = new()
        {
            new Movie { Id = 1, Title = "Jurassic Park", Director = "Steven Spielberg", Genre = "Adventure" },
            new Movie { Id = 2, Title = "Spider-Man", Director = "Sam Raimi", Genre = "Action" },
            new Movie { Id = 3, Title = "King Kong", Director = "Peter Jackson", Genre = "Adventure" },
            new Movie { Id = 4, Title = "Superman Returns", Director = "Bryan Singer", Genre = "Action" },
            new Movie { Id = 5, Title = "Titanic", Director = "James Cameron", Genre = "Drama" },
            new Movie { Id = 6, Title = "Transformers", Director = "Michael Bay", Genre = "Sci-Fi" },
            new Movie { Id = 7, Title = "Harry Potter and the Order of the Phoenix", Director = "David Yates", Genre = "Fantasy" },
            new Movie { Id = 8, Title = "Bee Movie", Director = "Simon J. Smith", Genre = "Animation" },
            new Movie { Id = 9, Title = "Interstellar", Director = "Christopher Nolan", Genre = "Sci-Fi" },
            new Movie { Id = 10, Title = "The Dark Knight", Director = "Christopher Nolan", Genre = "Action" },
            new Movie { Id = 11, Title = "Avatar", Director = "James Cameron", Genre = "Sci-Fi" },
            new Movie { Id = 12, Title = "Inception", Director = "Christopher Nolan", Genre = "Sci-Fi" },
            new Movie { Id = 13, Title = "The Matrix", Director = "Lana Wachowski, Lilly Wachowski", Genre = "Sci-Fi" },
            new Movie { Id = 14, Title = "Forrest Gump", Director = "Robert Zemeckis", Genre = "Drama" },
            new Movie { Id = 15, Title = "The Lion King", Director = "Roger Allers, Rob Minkoff", Genre = "Animation" },
            new Movie { Id = 16, Title = "Shrek", Director = "Andrew Adamson, Vicky Jenson", Genre = "Animation" },
            new Movie { Id = 17, Title = "Gladiator", Director = "Ridley Scott", Genre = "Action" },
            new Movie { Id = 18, Title = "The Lord of the Rings: The Fellowship of the Ring", Director = "Peter Jackson", Genre = "Fantasy" },
            new Movie { Id = 19, Title = "The Lord of the Rings: The Two Towers", Director = "Peter Jackson", Genre = "Fantasy" },
            new Movie { Id = 20, Title = "The Lord of the Rings: The Return of the King", Director = "Peter Jackson", Genre = "Fantasy" },
            new Movie { Id = 21, Title = "Finding Nemo", Director = "Andrew Stanton", Genre = "Animation" },
            new Movie { Id = 22, Title = "Toy Story", Director = "John Lasseter", Genre = "Animation" },
            new Movie { Id = 23, Title = "Pirates of the Caribbean", Director = "Gore Verbinski", Genre = "Adventure" },
            new Movie { Id = 24, Title = "The Avengers", Director = "Joss Whedon", Genre = "Action" },
            new Movie { Id = 25, Title = "Black Panther", Director = "Ryan Coogler", Genre = "Action" }
        };

        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(movies);
        }

        [HttpGet("joke")]
        public async Task<IActionResult> GetJoke()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://api.chucknorris.io/jokes/random");

                if (!response.IsSuccessStatusCode)
                {
                    return Ok(new
                    {
                        Message = "External API is currently unavailable.",
                        FallbackJoke = "External API failed, but MovieService still works."
                    });
                }

                var joke = await response.Content.ReadAsStringAsync();

                return Content(joke, "application/json");
            }
            catch
            {
                return Ok(new
                {
                    Message = "External API is currently unavailable.",
                    FallbackJoke = "External API failed, but MovieService still works."
                });
            }
        }

        [HttpGet("{id}/reviews")]
        public async Task<IActionResult> GetMovieReviews(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    $"https://localhost:7219/api/Reviews/movie/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    return Ok(new
                    {
                        Message = "ReviewService is currently unavailable.",
                        MovieId = id,
                        Reviews = new List<ReviewDto>()
                    });
                }

                var json = await response.Content.ReadAsStringAsync();

                var reviews = JsonSerializer.Deserialize<List<ReviewDto>>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                return Ok(reviews);
            }
            catch
            {
                return Ok(new
                {
                    Message = "ReviewService is currently unavailable, but MovieService still works.",
                    MovieId = id,
                    Reviews = new List<ReviewDto>()
                });
            }
        }
    }
}