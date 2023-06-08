using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Api.Controllers.Category
{
    public partial class CategoryController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryItem>>> GetList()
        {
            try
            {
                var categories = await _categoryService.GetList();

                if (categories == null || !categories.Any())
                    return NotFound();

                return Ok(categories);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"{GetListError} : { ex.Message}");
            }
        }
    }
}
