using BeerMapApi.Core.Interfaces;
using BeerMapApi.Infrastructure.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerMapApi.Infrastructure.Repositories
{
    public class BreweryRepository : IRepository<Core.Models.Brewery>
    {
        private readonly IMongoCollection<Brewery> _breweries;

        public BreweryRepository()
        {
            var client = new MongoClient(System.Environment.GetEnvironmentVariable("MONGODB_URI"));
            var database = client.GetDatabase("heroku_k8m8kp5m");

            _breweries = database.GetCollection<Brewery>("brewery");
        }

        public async Task<IEnumerable<Core.Models.Brewery>> ReadAsync()
        {
            return (await _breweries.FindAsync(b => true)).ToEnumerable().Select(b => new Core.Models.Brewery
            {
                Id = b.Id,
                Name = b.Name,
                Street = b.Street,
                City = b.City,
                State = b.State,
                PostalCode = b.PostalCode,
                Country = b.Country
            });
        }

        public async Task<Core.Models.Brewery> UpdateAsync(Core.Models.Brewery model)
        {
            var result = await _breweries.FindOneAndUpdateAsync(b => b.Id == model.Id, Builders<Brewery>.Update
                .Set(b => b.Latitude, model.Latitude)
                .Set(b => b.Longitude, model.Longitude));

            return new Core.Models.Brewery
            {
                Id = result.Id,
                Name = result.Name,
                Street = result.Street,
                City = result.City,
                State = result.State,
                PostalCode = result.PostalCode,
                Country = result.Country
            };
        }
    }
}
