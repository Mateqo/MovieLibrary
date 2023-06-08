using MovieLibrary.Core.Models.Common;
using MovieLibrary.Core.Models.Movies;
using MovieLibrary.Data.Extension;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Services.Movies
{
    public interface IMovieService : IDependency
    {
        Task<MovieGet> Get(int id);
        Task Update(int id, MovieUpdate movie);
        Task<int> Create(MovieCreate movie);
        Task<bool> Delete(int id);
        Task<SearchResult<MovieItem>> Filter(MovieFilter filter);
    }
}
