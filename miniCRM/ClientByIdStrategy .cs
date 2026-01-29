namespace miniCRM
{
    public class ClientByIdStrategy : IClientSearchStrategy
    {
        private readonly int _id;

        public ClientByIdStrategy(int id)
        {
            _id = id;
        }

        public bool IsMatch(Client client)
        {
            return client.Id == _id;
        }
    }
}
