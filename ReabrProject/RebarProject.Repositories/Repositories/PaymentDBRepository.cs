using MongoDB.Driver;
using ReabrProject.RebarProject.Repositories.Entities;
using ReabrProject.RebarProject.Repositories.Interfaces;
using System.Security.Principal;
using static MongoDB.Driver.WriteConcern;

namespace ReabrProject.RebarProject.Repositories.Repositories
{
    public class PaymentDBRepository:IPaymentDBRepository
    {
        private readonly IMongoCollection<Payment> _payment;
        public PaymentDBRepository(IRebarStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _payment = database.GetCollection<Payment>(settings.MenuCollectioName);
        }

        public Payment Create(Payment payment)
        {
            //recive orders for today
            List<Order> todayOrders = payment.Orders.Where(date => date.OrderDate.Date == DateTime.Today).ToList();

            //number of orders
            Console.WriteLine("number of orders for today:" + todayOrders.Count);
            //sum of orders
            Console.WriteLine("sum of orders for today:" + todayOrders.Sum(x => x.SumShakes));

            _payment.InsertOne(payment);
            return payment;
        }

        public List<Payment> GetAll()
        {
            var payments = _payment.Find(_ => true).ToList();
            var ids = payments.Select(payment => payment.PaymentId.ToString()).ToList();
            return payments;
        }

        public Payment GetById(string id)
        {
            return _payment.Find(payment => payment.PaymentId == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _payment.DeleteOne(payment => payment.PaymentId == id);
        }

        public void Update(string id, Payment payment)
        {
            _payment.ReplaceOne(payment => payment.PaymentId == id, payment);
        }
    }
}
