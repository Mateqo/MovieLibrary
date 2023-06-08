using MovieLibrary.Data.Extension;

namespace MovieLibrary.Data.Entities
{
    public class MovieCategory : DtoModel
    {
        public int MovieId { get; set; }

        public int CategoryId { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Category Category { get; set; }
    }
}
