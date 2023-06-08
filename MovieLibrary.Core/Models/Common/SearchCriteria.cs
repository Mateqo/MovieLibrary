using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Core.Models.Common
{
    public class SearchCriteria
    {
        [Required]
        public int PageNumber { get; set; }
        [Required]
        public int PageSize { get; set; }
    }
}
