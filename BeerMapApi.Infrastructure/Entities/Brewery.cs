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
        [BsonElement("street")]
        public string Street { get; set; }
        [BsonElement("city")]
        public string City { get; set; }
        [BsonElement("state")]
        public string State { get; set; }
        [BsonElement("postal_code")]
        public string PostalCode { get; set; }
        [BsonElement("country")]
        public string Country { get; set; }
        [BsonElement("latitude")]
        public string Latitude { get; set; }
        [BsonElement("longitude")]
        public string Longitude { get; set; }
    }
}
