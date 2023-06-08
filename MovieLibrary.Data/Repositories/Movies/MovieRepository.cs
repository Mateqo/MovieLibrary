using Microsoft.EntityFrameworkCore;
using MovieLibrary.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Data.Repositories.Movies
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieLibraryContext _movieLibraryContext;

        public MovieRepository(MovieLibraryContext movieLibraryContext)
        {
            _movieLibraryContext = movieLibraryContext;
        }

        public async Task<Movie> Get(int id)
        {
            return await _movieLibraryContext.Movies
                .AsNoTracking()
                .Include(m => m.MovieCategories)
                .ThenInclude(m => m.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IQueryable<Movie>> GetList()
        {
            var movies = await Task.FromResult(_movieLibraryContext.Movies
                 .AsNoTracking()
                 .Include(m => m.MovieCategories)
                 .ThenInclude(m => m.Category));

            return movies.AsQueryable();
        }
    }
}

