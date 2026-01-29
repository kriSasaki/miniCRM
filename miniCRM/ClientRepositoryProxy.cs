
namespace miniCRM
{
    public class ClientRepositoryProxy : IClientRepository
    {
        private readonly IClientRepository _realRepository;
        private Dictionary<int, Client> _cache;

        public ClientRepositoryProxy(IClientRepository realRepository)
        {
            _realRepository = realRepository;
            _cache = new Dictionary<int, Client>();
        }

        public IEnumerable<Client> GetAll()
        {
            return _realRepository.GetAll();
        }
        
        public void Add(Client entity)
        {
            _realRepository.Add(entity);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("[Proxy] Кэш очищен из-за добавления новой записи.");
            Console.ResetColor();
            _cache.Clear();
        }

        public Client GetById(int id)
        {
            if(_cache.TryGetValue(id, out var cachedClient))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"[Proxy] клиент с Id = {id} найден в кэше.");
                Console.ResetColor();
                return cachedClient;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[Proxy] Клиент с ID={id} не найден в кэше. Запрос к реальному репозиторию...");
            Console.ResetColor();
            var client = _realRepository.GetById(id);

            if(client != null)
            {
                _cache[id] = client;
            }

            return client;
        }

        public Task SaveAsync() => _realRepository.SaveAsync();
    }
}