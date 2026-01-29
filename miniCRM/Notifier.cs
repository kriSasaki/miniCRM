namespace miniCRM
{
    public class Notifier
    {
        public void OnClientAdded(Client client)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[Уведомление]: Добавлен новый клиент '{client.Name}' с Email: {client.Email}");
            Console.ResetColor();
        }
    }
}