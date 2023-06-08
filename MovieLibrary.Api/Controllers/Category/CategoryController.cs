using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Services.Categories;

namespace MovieLibrary.Api.Controllers.Category
{
    [Route("/v1/CategoryManagement")]
    [ApiController]
    public partial class CategoryController : ControllerBase
    {
        private const string GetError = "An error occurred while retrieving the category";
        private const string GetListError = "An error occurred while retrieving the categories";
        private const string CreateError = "An error occurred while creating the category";
        private const string UpdateError = "An error occurred while updating the category";
        private const string DeleteError = "An error occurred while deleting the category";

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
    }
}
