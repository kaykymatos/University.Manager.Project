using LiteDB;
using University.Manager.Project.Mobile.MauiAppUniversity.Models.Interfaces;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Repositories.Implementation
{
    public class BaseRepository<T> where T : class, IBaseModel
    {
        private readonly LiteDatabase _database;
        private readonly string _collectionName = "";
        public BaseRepository(LiteDatabase database, string collectionName)
        {
            _database = database;
            _collectionName = collectionName;
        }
        public void CreateMany(IEnumerable<T> models)
        {
            foreach (var item in models)
            {
                var col = _database.GetCollection<T>(_collectionName);
                col.Insert(item);

            }

        }
        public IEnumerable<T> FindAll()
        {
            return _database
                .GetCollection<T>(_collectionName)
                .Query()
                .ToList();
        }
        public T FindById(long id)
        {
            return _database
                .GetCollection<T>(_collectionName).FindById(id);
        }
        public void Create(T model)
        {
            var col = _database.GetCollection<T>(_collectionName);
            col.Insert(model);

        }
        public void Update(T model)
        {
            var col = _database.GetCollection<T>(_collectionName);
            col.Update(model);

        }
        public void DeleteById(long id)
        {
            var col = _database.GetCollection<T>(_collectionName);
            col.Delete(id);
        }
        public void DeletMultiple(IEnumerable<long> ids)
        {
            var col = _database.GetCollection<T>(_collectionName);
            foreach (var item in ids)
                col.Delete(item);

        }
    }
}
