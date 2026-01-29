namespace miniCRM
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly IStorage<T> _storage;
        protected List<T> _items;
        protected int _nextId = 1;

        protected BaseRepository(IStorage<T> storage)
        {
            _items = new List<T>();
            _storage = storage;
        }

        public async Task SaveAsync()
        {
            await _storage.SaveAsync(_items);
        }

        public void Add(T entity) => _items.Add(entity);

        public IEnumerable<T> GetAll() => _items;

        public abstract T GetById(int id);
    }
}