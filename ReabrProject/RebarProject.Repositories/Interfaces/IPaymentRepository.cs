using ReabrProject.RebarProject.Repositories.Entities;

namespace ReabrProject.RebarProject.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        List<Order> GetAll();
        Order GetById(Guid id);
        Order Create(Order order);
        void Update(Guid id, Order order);
        void Remove(Guid id);
    }
}
