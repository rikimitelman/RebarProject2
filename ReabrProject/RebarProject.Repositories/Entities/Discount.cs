using MongoDB.Bson.Serialization.Attributes;

namespace ReabrProject.RebarProject.Repositories.Entities
{
    public class Discount
    {
        public string Name { get; set; }
        public int Percent { get; set; }
    }
}
