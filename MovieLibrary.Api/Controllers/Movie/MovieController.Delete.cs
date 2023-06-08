using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MovieLibrary.Api.Controllers.Movie
{
    public partial class MovieController
    {
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var movie = await _movieService.Get(id);

                if (movie == null)
                    return NotFound();

                var isSucces = await _movieService.Delete(id);

                return Ok(isSucces);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"{DeleteError} : { ex.Message}");
            }
        }
    }
}
