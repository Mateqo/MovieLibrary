using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Models.Movies;
using System;
using System.Threading.Tasks;

namespace MovieLibrary.Api.Controllers.Movie
{
    public partial class MovieController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] MovieCreate movie)
        {
            try
            {
                if (movie == null)
                    return BadRequest("Ivalid data");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var id = await _movieService.Create(movie);

                return Ok(id);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"{CreateError} : { ex.Message}");
            }
        }
    }
}
