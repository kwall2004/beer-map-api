using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerMapApi.Core.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> ReadAsync();
    }
}
