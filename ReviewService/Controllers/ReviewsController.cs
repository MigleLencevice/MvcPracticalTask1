using Microsoft.AspNetCore.Mvc;
using ReviewService.Models;

namespace ReviewService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private static List<Review> reviews = new()
        {
            new Review { Id = 1, MovieId = 1, Reviewer = "Migle", Comment = "Amazing adventure movie", Rating = 10 },
            new Review { Id = 2, MovieId = 2, Reviewer = "John", Comment = "Classic superhero film", Rating = 9 },
            new Review { Id = 3, MovieId = 3, Reviewer = "Anna", Comment = "Very impressive visuals", Rating = 8 },
            new Review { Id = 4, MovieId = 4, Reviewer = "Mark", Comment = "Good action scenes", Rating = 7 },
            new Review { Id = 5, MovieId = 5, Reviewer = "Laura", Comment = "Very emotional story", Rating = 10 },
            new Review { Id = 6, MovieId = 6, Reviewer = "Chris", Comment = "Robots were awesome", Rating = 8 },
            new Review { Id = 7, MovieId = 7, Reviewer = "Emma", Comment = "Magical experience", Rating = 9 },
            new Review { Id = 8, MovieId = 8, Reviewer = "Tom", Comment = "Funny animated movie", Rating = 8 },
            new Review { Id = 9, MovieId = 9, Reviewer = "Sophia", Comment = "Mind blowing sci-fi", Rating = 10 },
            new Review { Id = 10, MovieId = 10, Reviewer = "Daniel", Comment = "Best Batman movie", Rating = 10 },
            new Review { Id = 11, MovieId = 11, Reviewer = "Olivia", Comment = "Beautiful world design", Rating = 9 },
            new Review { Id = 12, MovieId = 12, Reviewer = "James", Comment = "Very smart plot", Rating = 10 },
            new Review { Id = 13, MovieId = 13, Reviewer = "Lucas", Comment = "Legendary movie", Rating = 10 },
            new Review { Id = 14, MovieId = 14, Reviewer = "Ella", Comment = "Touching drama", Rating = 9 },
            new Review { Id = 15, MovieId = 15, Reviewer = "Noah", Comment = "Best childhood movie", Rating = 10 },
            new Review { Id = 16, MovieId = 16, Reviewer = "Mia", Comment = "Very funny animation", Rating = 8 },
            new Review { Id = 17, MovieId = 17, Reviewer = "Liam", Comment = "Epic battles", Rating = 9 },
            new Review { Id = 18, MovieId = 18, Reviewer = "Ava", Comment = "Fantastic fantasy world", Rating = 10 },
            new Review { Id = 19, MovieId = 19, Reviewer = "Benjamin", Comment = "Amazing sequel", Rating = 9 },
            new Review { Id = 20, MovieId = 20, Reviewer = "Charlotte", Comment = "Masterpiece ending", Rating = 10 },
            new Review { Id = 21, MovieId = 21, Reviewer = "Henry", Comment = "Cute and emotional", Rating = 9 },
            new Review { Id = 22, MovieId = 22, Reviewer = "Amelia", Comment = "Pixar classic", Rating = 10 },
            new Review { Id = 23, MovieId = 23, Reviewer = "Ethan", Comment = "Great pirate adventure", Rating = 8 },
            new Review { Id = 24, MovieId = 24, Reviewer = "Harper", Comment = "Awesome team movie", Rating = 9 },
            new Review { Id = 25, MovieId = 25, Reviewer = "Alexander", Comment = "Powerful Marvel movie", Rating = 9 }
        };

        [HttpGet]
        public IActionResult GetReviews()
        {
            return Ok(reviews);
        }

        [HttpGet("movie/{movieId}")]
        public IActionResult GetReviewsByMovie(int movieId)
        {
            var movieReviews = reviews
                .Where(r => r.MovieId == movieId)
                .ToList();

            return Ok(movieReviews);
        }
    }
}