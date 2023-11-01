using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ReabrProject.RebarProject.Repositories.Entities
{
    /*public enum ShakePrices
    {
        Small=22,
        Medium=25,
        Large=27
    }*/
    [BsonIgnoreExtraElements]
    public class Shake
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Prices")]
        public ShakePrices Prices { get; set; }

        [BsonElement("ShakeId")]
        public string ShakeId { get; set; }

        public Shake()
        {
            ShakeId=Guid.NewGuid().ToString();
        }
    }

    [BsonIgnoreExtraElements]
    public class ShakePrices
    {
        [BsonElement("Small")]
        public int Small { get; set; }
        [BsonElement("Medium")]
        public int Medium { get; set; }
        [BsonElement("Large")]
        public int Large { get; set; }

        public ShakePrices()
        {
            Small = 22;
            Medium = 26;
            Large = 30;
        }
    }

    }
