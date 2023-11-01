using MongoDB.Bson.Serialization.Attributes;

namespace ReabrProject.RebarProject.Repositories.Entities
{
    public class PaymentDB
    {
        [BsonElement("PaymentDBId")]
        public int PaymentDBId { get; set; }

        [BsonElement("PaymentList")]
        public List<Payment> PaymentList { get; set; }
    }
}
