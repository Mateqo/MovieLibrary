using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Models.Movies;
using System;
using System.Threading.Tasks;

namespace MovieLibrary.Api.Controllers.Movie
{
    public partial class MovieController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieGet>> Get(int id)
        {
            try
            {
                var movie = await _movieService.Get(id);

                if (movie == null)
                    return NotFound();

                return Ok(movie);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"{GetError} : { ex.Message}");
            }
        }
    }
}
