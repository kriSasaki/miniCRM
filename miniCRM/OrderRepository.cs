namespace miniCRM
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(IStorage<Order> storage) : base(storage)
        {
            if (_items.Any())
            {
                _nextId = _items.Cast<Order>().Max(o => o.Id) + 1;
            }
        }

        public override Order GetById(int id)
        {
            return _items.FirstOrDefault(o => o.Id == id);
        }
    }
}