using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Models.Categories;
using System;
using System.Threading.Tasks;

namespace MovieLibrary.Api.Controllers.Category
{
    public partial class CategoryController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CategoryCreate category)
        {
            try
            {
                if (category == null)
                    return BadRequest("Ivalid data");

                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                var id = await _categoryService.Create(category);

                return Ok(id);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"{CreateError} : { ex.Message}");
            }
        }
    }
}
