using MovieLibrary.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Core.Models.Categories
{
    public class CategoryUpdate
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public Category ToCategoryDto(int id)
        {
            return new Category()
            {
                Id = id,
                Name = Name
            };
        }
    }
}
