using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ReabrProject.RebarProject.Repositories.Entities
{
    public enum ShakePrices
    {
        S=22,
        M=25,
        L=27
    }
    [BsonIgnoreExtraElements]
    public class Shake
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Prices")]
        public ShakePrices Prices { get; set; }

        public string ShakeId { get; set; }

        public Shake()
        {
            ShakeId=Guid.NewGuid().ToString();
        }
    }

    

}
