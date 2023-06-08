using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Models.Movies;
using System;
using System.Threading.Tasks;

namespace MovieLibrary.Api.Controllers.Movie
{
    public partial class MovieController
    {
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] MovieUpdate movie)
        {
            try
            {
                var movieExists = await _movieService.Get(id);

                if (movieExists == null)
                    return NotFound();

                if (movie == null)
                    return BadRequest("Ivalid data");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _movieService.Update(id, movie);

                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"{UpdateError} : { ex.Message}");
            }
        }
    }
}
