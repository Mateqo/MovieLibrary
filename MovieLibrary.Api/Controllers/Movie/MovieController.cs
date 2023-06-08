using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Services.Movies;

namespace MovieLibrary.Api.Controllers.Movie
{
    [Route("/v1/MovieManagement")]
    [ApiController]
    public partial class MovieController : ControllerBase
    {
        private const string GetError = "An error occurred while retrieving the movie";
        private const string CreateError = "An error occurred while creating the movie";
        private const string UpdateError = "An error occurred while updating the movie";
        private const string DeleteError = "An error occurred while deleting the movie";

        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
    }
}
