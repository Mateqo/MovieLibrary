using MovieLibrary.Core.Models.Categories;
using MovieLibrary.Data.Extension;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Services.Categories
{
    public interface ICategoryService : IDependency
    {
        Task<CategoryGet> Get(int id);
        Task<IEnumerable<CategoryItem>> GetList();
        Task<int> Create(CategoryCreate category);
        Task Update(int id, CategoryUpdate category);
        Task<bool> Delete(int id);
    }
}
