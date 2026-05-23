using MovieService.Interfaces;
using MovieService.Models;

namespace MovieService.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private static List<Movie> movies = new()
        {
            new Movie
            {
                Id = 1,
                Title = "Interstellar",
                Director = "Christopher Nolan",
                Genre = "Sci-Fi"
            },

            new Movie
            {
                Id = 2,
                Title = "Titanic",
                Director = "James Cameron",
                Genre = "Drama"
            }
        };

        public IEnumerable<Movie> GetAllMovies()
        {
            return movies;
        }
    }
}