namespace miniCRM
{
    public record Order(int Id, int ClientId, string Description, decimal Amount, DateOnly DueDate);
}