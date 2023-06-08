using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MovieLibrary.Api.Controllers.Category
{
    public partial class CategoryController
    {
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var category = await _categoryService.Get(id);

                if (category == null)
                    return NotFound();

                var isSucces = await _categoryService.Delete(id);

                return Ok(isSucces);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"{DeleteError} : { ex.Message}");
            }
        }
    }
}
