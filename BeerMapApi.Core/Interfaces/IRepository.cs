using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerMapApi.Core.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> CreateAsync(TEntity model);
        Task<IEnumerable<TEntity>> ReadAsync();
        Task<TEntity> UpdateAsync(TEntity model);
    }
}
