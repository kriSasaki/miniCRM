namespace miniCRM
{
    public interface IClientReader
    {
        IEnumerable<Client> GetAllClients();
        IEnumerable<Client> FindClients(IClientSearchStrategy strategy);
    }
}
