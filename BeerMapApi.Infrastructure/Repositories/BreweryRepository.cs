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
        private readonly IMongoCollection<Brewery> _collection;

        public BreweryRepository()
        {
            var client = new MongoClient(System.Environment.GetEnvironmentVariable("MONGODB_URI"));
            var database = client.GetDatabase("heroku_k8m8kp5m");

            _collection = database.GetCollection<Brewery>("brewery");
        }

        public async Task<Core.Models.Brewery> CreateAsync(Core.Models.Brewery model)
        {
            var document = new Brewery
            {
                Name = model.Name,
                Street = model.Street,
                City = model.City,
                State = model.State,
                PostalCode = model.PostalCode,
                Country = model.Country,
                Latitude = model.Latitude,
                Longitude = model.Longitude
            };

            await _collection.InsertOneAsync(document);

            model.Id = document.Id;

            return model;
        }

        public async Task<IEnumerable<Core.Models.Brewery>> ReadAsync()
        {
            return (await _collection.FindAsync(b => true)).ToEnumerable().Select(d => new Core.Models.Brewery
            {
                Id = d.Id,
                Name = d.Name,
                Street = d.Street,
                City = d.City,
                State = d.State,
                PostalCode = d.PostalCode,
                Country = d.Country,
                Latitude = d.Latitude,
                Longitude = d.Longitude
            });
        }

        public async Task<Core.Models.Brewery> UpdateAsync(Core.Models.Brewery model)
        {
            var result = await _collection.FindOneAndUpdateAsync(d => d.Id == model.Id, Builders<Brewery>.Update
                .Set(d => d.Latitude, model.Latitude)
                .Set(d => d.Longitude, model.Longitude));

            return new Core.Models.Brewery
            {
                Id = result.Id,
                Name = result.Name,
                Street = result.Street,
                City = result.City,
                State = result.State,
                PostalCode = result.PostalCode,
                Country = result.Country,
                Latitude = result.Latitude,
                Longitude = result.Longitude
            };
        }
    }
}
