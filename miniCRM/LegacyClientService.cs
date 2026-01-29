namespace miniCRM
{
    public class LegacyClientService
    {
        public string GetClientsAsString()
        {
            // В реальности здесь мог бы быть запрос к старому API или базе данных
            return "101,John Doe,john@legacy.com;102,Jane Smith,jane@legacy.com";
        }
    }
}