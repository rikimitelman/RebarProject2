using MongoDB.Driver;
using ReabrProject.RebarProject.Repositories.Entities;
using ReabrProject.RebarProject.Repositories.Interfaces;
using System.ComponentModel.Design;

namespace ReabrProject.RebarProject.Repositories.Repositories
{
    public class MenuRepository:IMenuRepository
    {
        private readonly IMongoCollection<Shake> _shake;
        public MenuRepository(IRebarStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _shake = database.GetCollection<Shake>(settings.MenuCollectioName);
        }

        public Shake Create(Shake shake)
        {
            _shake.InsertOne(shake);
            return shake;
        }

        public List<Shake> GetAll()
        {
            var shakes = _shake.Find(_ => true).ToList();
            var ids = shakes.Select(shake => shake.ShakeId.ToString()).ToList();
            Console.WriteLine(shakes[1].ShakeId.GetType());
            return shakes;
        }

        public Shake GetById(string id)
        {
            return _shake.Find(shake => shake.ShakeId == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _shake.DeleteOne(shake => shake.ShakeId == id);
        }

        public void Update(string  id, Shake shake)
        {
            _shake.ReplaceOne(shake => shake.ShakeId == id, shake);
        }
    }
}
