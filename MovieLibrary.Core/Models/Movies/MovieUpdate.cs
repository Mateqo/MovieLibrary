using MovieLibrary.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Core.Models.Movies
{
    public class MovieUpdate
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]

        public decimal ImdbRating { get; set; }
        public IEnumerable<int> CategoryIds { get; set; }

        public Movie ToMovieDto(int id)
        {
            return new Movie()
            {
                Id = id,
                Title = Title,
                Description = Description,
                Year = Year,
                ImdbRating = ImdbRating,
            };
        }
    }
}
