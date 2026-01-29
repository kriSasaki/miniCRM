namespace miniCRM
{
    public interface IClientSearchStrategy
    {
        bool IsMatch(Client client);
    }
}
