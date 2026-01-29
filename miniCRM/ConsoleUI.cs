namespace miniCRM
{
    public class ConsoleUI
    {
        private readonly IEnumerable<IClientReader> _clientReaders;
        private readonly IClientWriter _clientWriter;

        public ConsoleUI(IEnumerable<IClientReader> clientReaders, IClientWriter clientWriter)
        {
            _clientReaders = clientReaders;
            _clientWriter = clientWriter;
        }

        public void Show(BaseReportGenerator report1, BaseReportGenerator report2)
        {
            ShowAllClients();
        }

        public void ShowAllClients()
        {
            Console.WriteLine("\n--- Список ВСЕХ клиентов из ВСЕХ источников ---");

            // Объединяем клиентов из всех источников
            var allClients = _clientReaders.SelectMany(reader => reader.GetAllClients());

            foreach (var client in allClients)
            {
                Console.WriteLine(client);
            }
        }
    }
}