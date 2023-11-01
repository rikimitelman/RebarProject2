using MongoDB.Driver;
using ReabrProject.RebarProject.Repositories.Entities;
using ReabrProject.RebarProject.Repositories.Interfaces;
using System.Text.RegularExpressions;

namespace ReabrProject.RebarProject.Repositories.Repositories
{
    public class PaymentRepository:IPaymentRepository
    {
        private readonly IMongoCollection<Order> _order;

        public PaymentRepository(IRebarStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database =mongoClient.GetDatabase(settings.DatabaseName);
            _order = database.GetCollection<Order>(settings.PaymentCollectionName);
        }

        public Order Create(Order order)
        {
            //name validation
            string name = "^[A-Za-z]+$";
            if (!Regex.IsMatch(order.CustomerName, name))
                throw new Exception("Invalid name");

            //check if there is any discount
            UpdateShakeDiscounts(order.Shakes,order.Discounts);
            
            //add shake's price to the whole sum
            Console.WriteLine("please enter the price of your rebar. S=22, M=26, L=30");
            int price = Convert.ToInt32(Console.ReadLine());
            order.addShake(price); 

            order.FinishOrder = DateTime.Now;
            TimeSpan timeDifference = order.FinishOrder.Subtract(order.OrderDate);
            //add the order
            _order.InsertOne(order);
            Console.WriteLine($"Order number: {order.OrderId}  has been successfully completed, The total price is: {order.SumShakes}");
            return order;
        }

        public void UpdateShakeDiscounts(List<Shake> shakes, List<Discount> discounts)
        {
            foreach (Shake shake in shakes)
            {
                foreach (Discount discount in discounts)
                {
                    if (shake.Name == discount.Name)
                    {
                        double discountPercentage = (100 - discount.Percent) / 100.0;
                        shake.Prices.Small = (int)(shake.Prices.Small * discountPercentage);
                        shake.Prices.Medium = (int)(shake.Prices.Medium * discountPercentage);
                        shake.Prices.Large = (int)(shake.Prices.Large * discountPercentage);
                        break;
                    }
                }
            }
        }

        public List<Order> GetAll()
        {
            return _order.Find(order => true).ToList();
        }

        public Order GetById(string id)
        {
            return _order.Find(order => order.OrderId == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _order.DeleteOne(order => order.OrderId == id);
        }

        public void Update(string id, Order order)
        {
            _order.ReplaceOne(order => order.OrderId == id, order);
        }

    }
}
