using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerMapApi.Core.Interfaces
{
    public interface IUseCase<TEntity>
    {
        Task<TEntity> Create(TEntity model);
        Task<IEnumerable<TEntity>> Read();
        Task<TEntity> Update(TEntity model);
    }
}
