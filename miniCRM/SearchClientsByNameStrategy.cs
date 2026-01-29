namespace miniCRM
{
    public class SearchClientsByNameStrategy : IClientSearchStrategy
    {
        private readonly string _name;

        public SearchClientsByNameStrategy(string name)
        {
            _name = name.ToLower();
        }

        public bool IsMatch(Client client)
        {
            return client.Name.ToLower().Contains(_name);
        }
    }
}