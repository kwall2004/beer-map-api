using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerMapApi.Core.Interfaces
{
    public interface IUseCase<TEntity>
    {
        Task<IEnumerable<TEntity>> Read();
        Task<TEntity> Update();
    }
}
