namespace miniCRM
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(IStorage<Order> storage) : base(storage)
        {
        }

        public override Order GetById(int id)
        {
            return _items.FirstOrDefault(o => o.Id == id);
        }
    }
}