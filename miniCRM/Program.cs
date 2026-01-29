using miniCRM;

public class Program
{
    public static async Task Main(string[] args)
    {
        var crmService = CrmService.Instance;
        var notifier = new Notifier();

        var legacyService = new LegacyClientService();
        var legacyAdapter = new LegacyClientAdapter(legacyService);

        var clientReaders = new List<IClientReader>
        {
            crmService,     // Наш основной сервис
            legacyAdapter   // Адаптированный старый сервис
        };

        var ui = new ConsoleUI(clientReaders, crmService);

        crmService.ClientAdded += notifier.OnClientAdded;

        ReportGeneratorFactory clientReportFactory = new ClientListReportFactory();
        ReportGeneratorFactory ordersReportFactory = new ClientOrdersReportFactory();

        BaseReportGenerator clientReport = clientReportFactory.CreateGenerator(crmService, crmService);
        BaseReportGenerator ordersReport = ordersReportFactory.CreateGenerator(crmService, crmService);

        ui.Show(clientReport, ordersReport);
    }

    public static void PrintCollection<T>(List<T> items)
    {
        if (!items.Any())
        {
            Console.WriteLine("Список пуст.");
            return;
        }
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}