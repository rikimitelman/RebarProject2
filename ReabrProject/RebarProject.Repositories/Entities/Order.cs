using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ReabrProject.RebarProject.Repositories.Entities
{
    [BsonIgnoreExtraElements]
    public class Order
    {
        [BsonElement("Shakes")]
        public List<Shake> Shakes { get; set; }

        [BsonElement("SumShakes")]
        public int SumShakes { get; set; }

        [BsonElement("OrderId")]
        public string OrderId { get; set; }

        [BsonElement("CustomerName")]
        public string CustomerName { get; set; }

        [BsonElement("OrderDate")]
        public DateTime OrderDate { get; set; }

        [BsonElement("FinishOrder")]
        public DateTime FinishOrder { get; set; }

        [BsonElement("Discount")]
        public List<Discount> Discounts { get; set; }

        public Order()
        {
            OrderId = Guid.NewGuid().ToString();
        }
        public void addShake (int price)
        {
            this.SumShakes += price;
        }

    }
}
