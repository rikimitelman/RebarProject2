using ReabrProject.RebarProject.Repositories.Entities;

namespace ReabrProject.RebarProject.Repositories.Interfaces
{
    public interface IMenuRepository
    {
        List<Shake> GetAll();
        Shake GetById(string id);
        Shake Create(Shake shake);
        void Update(string id, Shake shake);
        void Remove(string id);
    }
}
