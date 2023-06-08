using System.Collections.Generic;

namespace MovieLibrary.Core.Models.Common
{
    public class SearchResult<T>
    {
        public int TotalRows { get; set; }
        public IEnumerable<T> Items  { get; set; }
    }
}
