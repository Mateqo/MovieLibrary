using Microsoft.EntityFrameworkCore;
using MovieLibrary.Data.Extension;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieLibrary.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : DtoModel
    {
        private readonly MovieLibraryContext _movieLibraryContext;

        public Repository(MovieLibraryContext movieLibraryContext)
        {
            _movieLibraryContext = movieLibraryContext;
        }

        public async Task<T> Get(int id)
        {
            return await _movieLibraryContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> GetList()
        {
            return await _movieLibraryContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task Update(T model)
        {
            _movieLibraryContext.Set<T>().Update(model);
            await _movieLibraryContext.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var model = await _movieLibraryContext.Set<T>().FindAsync(id);

            if (model == null)
                return false;

            _movieLibraryContext.Set<T>().Remove(model);
            await _movieLibraryContext.SaveChangesAsync();

            return true;
        }

        public async Task<int> Create(T model)
        {
            await _movieLibraryContext.Set<T>().AddAsync(model);
            await _movieLibraryContext.SaveChangesAsync();

            return model.Id;
        }

    }
}
