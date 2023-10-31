using MongoDB.Driver;
using ReabrProject.RebarProject.Repositories.Entities;
using ReabrProject.RebarProject.Repositories.Interfaces;
using System.ComponentModel.Design;

namespace ReabrProject.RebarProject.Repositories.Repositories
{
    public class MenuRepository:IMenuRepository
    {
        private readonly IMongoCollection<Shake> _shake;
        public MenuRepository(IRebarStoreDatabaseSettings settings, MongoClient mongoClient)
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
            return _shake.Find(shake => true).ToList();
        }

        public Shake GetById(Guid id)
        {
            return _shake.Find(shake => shake.ShakeId == id).FirstOrDefault();
        }

        public void Remove(Guid id)
        {
            _shake.DeleteOne(shake => shake.ShakeId == id);
        }

        public void Update(Guid id, Shake shake)
        {
            _shake.ReplaceOne(shake => shake.ShakeId == id, shake);
        }
    }
}
