using ReabrProject.RebarProject.Repositories.Entities;

namespace ReabrProject.RebarProject.Repositories.Interfaces
{
    public interface IPaymentDBRepository
    {
        List<Payment> GetAll();
        Payment GetById(string id);
        Payment Create(Payment payment);
        void Update(string id, Payment payment);
        void Remove(string id);
    }
}
