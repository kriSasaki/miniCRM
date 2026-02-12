namespace miniCRM
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(IStorage<Client> storage) : base(storage)
        {
            // nextId initialization moved to BaseRepository
        }

        public override Client GetById(int id)
        {
            return _items.FirstOrDefault(c => c.Id == id);
        }
    }
}