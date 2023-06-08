using MovieLibrary.Data.Entities;

namespace MovieLibrary.Core.Models.Categories
{
    public class CategoryItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CategoryItem(Category categoryDto)
        {
            Id = categoryDto.Id;
            Name = categoryDto.Name;
        }
    }
}
