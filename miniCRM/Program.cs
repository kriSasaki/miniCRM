using miniCRM;

public class Program
{
    public static async Task Main(string[] args)
    {
        var crmService = CrmService.Instance;
        var notifier = new Notifier();
        var ui = new ConsoleUI(crmService);

        crmService.ClientAdded += notifier.OnClientAdded;

        ui.Show();
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

    //Console.WriteLine("--- Тестирование моделей данных ---");

    //// Создаем клиента
    //var client1 = new Client(1, "Иван Петров", "ivan@test.com", DateTime.Now);
    //Console.WriteLine("Создан клиент:");
    //Console.WriteLine(client1);

    //// Создаем заказ для этого клиента
    //var order1 = new Order(101, client1.Id, "Разработка сайта", 50000.00m, DateOnly.FromDateTime(DateTime.Now.AddDays(30)));
    //Console.WriteLine("\nСоздан заказ:");
    //Console.WriteLine(order1);

    //// Демонстрация сравнения по значению
    //var client1_copy = new Client(1, "Иван Петров", "ivan@test.com", client1.CreatedAt);
    //Console.WriteLine($"\nРавны ли client1 и client1_copy? -> {client1 == client1_copy}");

    //Console.ReadLine();
}