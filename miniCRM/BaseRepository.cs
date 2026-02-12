using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniCRM
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly IStorage<T> _storage;
        protected List<T> _items;
        protected int _nextId = 1;

        protected BaseRepository(IStorage<T> storage)
        {
            _storage = storage;
            _items = storage?.Load() ?? new List<T>();

            // Вычисляем следующий Id, если есть сущности с Id
            var ids = _items.OfType<IEntity>().Select(e => e.Id);
            if (ids.Any())
            {
                _nextId = ids.Max() + 1;
            }
        }

        public async Task SaveAsync()
        {
            if (_storage != null)
            {
                await _storage.SaveAsync(_items);
            }
        }

        public void Add(T entity)
        {
            if (entity is IEntity e)
            {
                if (e.Id == 0)
                {
                    e.Id = _nextId++;
                }
                else
                {
                    _nextId = Math.Max(_nextId, e.Id + 1);
                }
            }

            _items.Add(entity);
        }

        public IEnumerable<T> GetAll() => _items;

        public abstract T GetById(int id);
    }
}