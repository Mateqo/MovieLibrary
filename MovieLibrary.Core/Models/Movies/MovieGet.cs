using MovieLibrary.Core.Models.Categories;
using MovieLibrary.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Core.Models.Movies
{
    public class MovieGet
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        public decimal ImdbRating { get; set; }
        public IEnumerable<CategoryItem> Categories { get; set; }

        public MovieGet(Movie movieDto)
        {
            Id = movieDto.Id;
            Title = movieDto.Title;
            Description = movieDto.Description;
            ImdbRating = movieDto.ImdbRating;
            Year = movieDto.Year;
            Categories = movieDto.MovieCategories?.Select(x => new CategoryItem(x.Category)) ?? new List<CategoryItem>();
        }
    }
}
