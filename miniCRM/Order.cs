using System;

namespace miniCRM
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int ClientId { get; init; }
        public string Description { get; init; }
        public decimal Amount { get; init; }
        public DateOnly DueDate { get; init; }

        public Order(int id, int clientId, string description, decimal amount, DateOnly dueDate)
        {
            Id = id;
            ClientId = clientId;
            Description = description;
            Amount = amount;
            DueDate = dueDate;
        }

        public override string ToString()
        {
            return $"{Id}: Client={ClientId}, {Description}, {Amount:C}, due {DueDate}";
        }
    }
}