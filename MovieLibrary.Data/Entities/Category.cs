using MovieLibrary.Data.Extension;
using System.Collections.Generic;

namespace MovieLibrary.Data.Entities
{
    public class Category : DtoModel
    {
        public Category()
        {
            this.MovieCategories = new List<MovieCategory>();
        }

        public string Name { get; set; }

        public virtual ICollection<MovieCategory> MovieCategories { get; set; }
    }
}
