using MovieLibrary.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Core.Models.Categories
{
    public class CategoryCreate
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public Category ToCategoryDto()
        {
            return new Category()
            {
                Name = Name
            };
        }
    }
}
