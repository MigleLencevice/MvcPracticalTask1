using MovieService.Interfaces;
using MovieService.Models;

namespace MovieService.Services
{
    public class MovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _movieRepository.GetAllMovies();
        }
    }
}