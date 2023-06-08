using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Extension;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Data.Repositories.Movies
{
    public interface IMovieRepository : IDependency
    {
        Task<Movie> Get(int id);
        Task<IQueryable<Movie>> GetList();
    }
}
