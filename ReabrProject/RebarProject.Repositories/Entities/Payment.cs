using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ReabrProject.RebarProject.Repositories.Entities
{

    [BsonIgnoreExtraElements]
    public class Payment
    {
        [BsonElement("PaymentId")]
        public string PaymentId { get; set; }

        [BsonElement("Orders")]
        public List<Order> Orders { get; set; }

        [BsonElement("SumOrders")]
        public int SumOrders { get; set; }

        [BsonElement("NumOrders")]
        public int NumOrders { get; set; }

        public Payment()
        {
            PaymentId= Guid.NewGuid().ToString();
        }
    }
}
