using MovieLibrary.Core.Models.Categories;
using MovieLibrary.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Core.Models.Movies
{
    public class MovieItem
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        public decimal ImdbRating { get; set; }
        public IEnumerable<CategoryItem> Categories { get; set; }

        public MovieItem(Movie movieDto)
        {
            Id = movieDto.Id;
            Title = movieDto.Title;
            Description = movieDto.Description;
            Year = movieDto.Year;
            ImdbRating = movieDto.ImdbRating;

            Categories = (movieDto.MovieCategories != null && movieDto.MovieCategories.Any()) ?
                movieDto.MovieCategories.Select(c => new CategoryItem(c.Category)) :
                new List<CategoryItem>();
        }
    }
}
