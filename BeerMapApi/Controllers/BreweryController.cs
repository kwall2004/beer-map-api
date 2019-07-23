using BeerMapApi.Core.Interfaces;
using BeerMapApi.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerMapApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweryController : ControllerBase
    {
        private readonly IUseCase<Brewery> _useCase;

        public BreweryController(IUseCase<Brewery> useCase)
        {
            _useCase = useCase;
        }

        [HttpGet]
        public async Task<IEnumerable<Brewery>> Read()
        {
            return await _useCase.Read();
        }

        [HttpPatch]
        public async Task<Brewery> Update(Brewery model)
        {
            return await _useCase.Update();
        }
    }
}