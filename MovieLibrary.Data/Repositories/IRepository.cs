using MovieLibrary.Data.Extension;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieLibrary.Data.Repositories
{
    public interface IRepository<T> where T : DtoModel
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetList();
        Task Update(T model);
        Task<bool> Delete(int id);
        Task<int> Create(T model);
    }
}
