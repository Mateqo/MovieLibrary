using MovieLibrary.Data.Entities;

namespace MovieLibrary.Core.Models.Categories
{
    public class CategoryGet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CategoryGet(Category categoryDto)
        {
            Id = categoryDto.Id;
            Name = categoryDto.Name;
        }
    }
}
