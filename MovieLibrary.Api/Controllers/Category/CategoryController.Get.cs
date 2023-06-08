using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Models.Categories;
using System;
using System.Threading.Tasks;

namespace MovieLibrary.Api.Controllers.Category
{
    public partial class CategoryController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryGet>> Get(int id)
        {
            try
            {
                var category = await _categoryService.Get(id);

                if (category == null)
                    return NotFound();

                return Ok(category);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"{GetError} : { ex.Message}");
            }
        }
    }
}
