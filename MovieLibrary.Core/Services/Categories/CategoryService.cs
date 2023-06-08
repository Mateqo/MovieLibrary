using MovieLibrary.Core.Models.Categories;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Services.Categories
{
    public class CategoryService : ICategoryService
    {

        private readonly IRepository<Category> _categoryBasRrepository;

        public CategoryService(IRepository<Category> categoryBaserepository)
        {
            _categoryBasRrepository = categoryBaserepository;
        }

        public async Task<int> Create(CategoryCreate category)
        {
            return await _categoryBasRrepository.Create(category.ToCategoryDto());
        }

        public async Task<CategoryGet> Get(int id)
        {
            var categoryDto = await _categoryBasRrepository.Get(id);

            return categoryDto != null ? new CategoryGet(categoryDto) : null;
        }

        public async Task<IEnumerable<CategoryItem>> GetList()
        {
            var categoryDto = await _categoryBasRrepository.GetList();

            return categoryDto.Select(x => new CategoryItem(x));
        }

        public async Task Update(int id, CategoryUpdate category)
        {
            await _categoryBasRrepository.Update(category.ToCategoryDto(id));
        }

        public async Task<bool> Delete(int id)
        {
            return await _categoryBasRrepository.Delete(id);
        }
    }
}
