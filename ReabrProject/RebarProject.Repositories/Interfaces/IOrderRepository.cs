using ReabrProject.RebarProject.Repositories.Entities;

namespace ReabrProject.RebarProject.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        List<Shake> GetAll();
        Shake GetById(Guid id);
        Shake Create(Shake shake);
        void Update(Guid id, Shake shake);
        void Remove(Guid id);
    }
}
