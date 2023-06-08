using MovieLibrary.Core.Models.Common;
using System.Collections.Generic;

namespace MovieLibrary.Core.Models.Movies
{
    public class MovieFilter : SearchCriteria
    {
        public string Name { get; set; }
        public decimal? MinImdb { get; set; }
        public decimal? MaxImdb { get; set; }
        public IEnumerable<int> CategoryIds { get; set; }
    }
}
