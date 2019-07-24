using BeerMapApi.Core.Interfaces;
using BeerMapApi.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerMapApi.Core.UseCases
{
    public class BreweryUseCase : IUseCase<Brewery>
    {
        private readonly IRepository<Brewery> _repository;

        public BreweryUseCase(IRepository<Brewery> repository)
        {
            _repository = repository;
        }

        public async Task<Brewery> Create(Brewery model)
        {
            return await _repository.CreateAsync(model);
        }

        public async Task<IEnumerable<Brewery>> Read()
        {
            return await _repository.ReadAsync();
        }

        public async Task<Brewery> Update(Brewery model)
        {
            return await _repository.UpdateAsync(model);
        }
    }
}
