using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BeerMapApi.Infrastructure.Entities
{
    [BsonIgnoreExtraElements]
    public class Brewery
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("latitude")]
        public decimal Latitude { get; set; }
        [BsonElement("longitude")]
        public decimal Longitude { get; set; }
    }
}
