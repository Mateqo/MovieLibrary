using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Models.Categories;
using System;
using System.Threading.Tasks;

namespace MovieLibrary.Api.Controllers.Category
{
    public partial class CategoryController
    {
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] CategoryUpdate category)
        {
            try
            {
                var categoryExists = await _categoryService.Get(id);

                if (categoryExists == null)
                    return NotFound();

                if (category == null)
                    return BadRequest("Ivalid data");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _categoryService.Update(id, category);

                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"{UpdateError} : { ex.Message}");
            }
        }
    }
}
