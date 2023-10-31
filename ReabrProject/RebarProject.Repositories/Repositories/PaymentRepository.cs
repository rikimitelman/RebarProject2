using MongoDB.Driver;
using ReabrProject.RebarProject.Repositories.Entities;
using ReabrProject.RebarProject.Repositories.Interfaces;

namespace ReabrProject.RebarProject.Repositories.Repositories
{
    public class PaymentRepository:IPaymentRepository
    {
        private readonly IMongoCollection<Order> _order;

        public PaymentRepository(IRebarStoreDatabaseSettings settings, MongoClient mongoClient)
        {
            var database =mongoClient.GetDatabase(settings.DatabaseName);
            _order = database.GetCollection<Order>(settings.PaymentCollectionName);
        }

        public Order Create(Order order)
        {
            _order.InsertOne(order);
            return order;
        }

        public List<Order> GetAll()
        {
            return _order.Find(order => true).ToList();
        }

        public Order GetById(Guid id)
        {
            return _order.Find(order => order.OrderId == id).FirstOrDefault();
        }

        public void Remove(Guid id)
        {
            _order.DeleteOne(order => order.OrderId == id);
        }

        public void Update(Guid id, Order order)
        {
            _order.ReplaceOne(order => order.OrderId == id, order);
        }
    }
}
