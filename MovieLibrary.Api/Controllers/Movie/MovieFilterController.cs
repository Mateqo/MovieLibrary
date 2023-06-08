using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Models.Common;
using MovieLibrary.Core.Models.Movies;
using MovieLibrary.Core.Services.Movies;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Api.Controllers.Movie
{
    [Route("/v1/Movie/Filter")]
    [ApiController]
    public class MovieFilterController : ControllerBase
    {
        private const string GetListError = "An error occurred while retrieving the movies";

        private readonly IMovieService _movieService;

        public MovieFilterController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<SearchResult<MovieItem>>> Filter([FromQuery] MovieFilter filter)
        {
            try
            {
                var movies = await _movieService.Filter(filter);

                if (movies.Items.Count() == 0)
                    return NotFound();

                return Ok(movies);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"{GetListError} : { ex.Message}");
            }
        }
    }
}
