using MovieService.Models;

namespace MovieService.Interfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();
    }
}