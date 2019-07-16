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
            var client = new MongoClient("mongodb://heroku_k8m8kp5m:i1iqd9246vjvb3m53mnmkbft6l@ds255005.mlab.com:55005/heroku_k8m8kp5m");
            var database = client.GetDatabase("heroku_k8m8kp5m");

            _breweries = database.GetCollection<Brewery>("brewery");
        }

        public async Task<IEnumerable<Core.Models.Brewery>> ReadAsync()
        {
            return (await _breweries.FindAsync(b => true)).ToEnumerable().Select(e => new Core.Models.Brewery
            {
                Id = e.Id,
                Name = e.Name
            });
        }
    }
}
