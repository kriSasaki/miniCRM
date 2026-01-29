namespace miniCRM
{
    public interface IOrderReader
    {
        IEnumerable<Order> GetAllOrders();
    }
}