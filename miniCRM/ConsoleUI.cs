namespace miniCRM
{
    public class ConsoleUI
    {
        private readonly CrmService _crmService;

        public ConsoleUI(CrmService crmService)
        {
            _crmService = crmService;
        }

        public void Show()
        {
            Console.WriteLine("--- Система CRM запущена ---");
            _crmService.AddClient(new Client(1, "Иван Иванов", "ivan@example.com", DateTime.Now));
            Console.WriteLine("\n--- Демонстрация паттерна Стратегия ---");
            var nameStrategy = new SearchClientsByNameStrategy("Иван");
            var foundByName = _crmService.FindClients(nameStrategy);

            foreach (var client in foundByName)
            {
                Console.WriteLine(client);
            }
        }
    }
}
