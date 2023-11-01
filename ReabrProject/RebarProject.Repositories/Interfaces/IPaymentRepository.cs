using ReabrProject.RebarProject.Repositories.Entities;

namespace ReabrProject.RebarProject.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        List<Order> GetAll();
        Order GetById(string id);
        Order Create(Order order);
        void Update(string id, Order order);
        void Remove(string id);
        void UpdateShakeDiscounts(List<Shake> shakes, List<Discount> discounts);
    }
}
