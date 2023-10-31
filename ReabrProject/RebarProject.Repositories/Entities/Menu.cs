using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ReabrProject.RebarProject.Repositories.Entities
{
    [BsonIgnoreExtraElements]
    public class Menu
    {
        [BsonElement("Shakes")]
        List<Shake> Shakes;

        public string MenuId { get; set; }

        public Menu()
        {
            MenuId= Guid.NewGuid().ToString();
        }
    }
}
