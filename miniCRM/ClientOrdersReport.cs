namespace miniCRM
{
    internal class ClientOrdersReport : BaseReportGenerator
    {
        public ClientOrdersReport(IClientReader clientReader, IOrderReader orderReader) : base(clientReader, orderReader) { }

        protected override void GenerateBody()
        {
            Console.WriteLine("\n--- Отчет по заказам клиентов ---");
            var clients = _clientReader.GetAllClients();

            foreach (var client in clients)
            {
                Console.WriteLine($"\nКлиент: {client.Name} (ID: {client.Id})");

                var clientOrders = _orderReader.GetAllOrders().Where(o => o.ClientId == client.Id);

                if (clientOrders.Any())
                {
                    foreach (var order in clientOrders)
                    {
                        Console.WriteLine($"  - Заказ #{order.Id}: {order.Description} на сумму {order.Amount:C}");
                    }
                }
                else
                {
                    Console.WriteLine("  - Заказов нет.");
                }
            }
        }
    }
}