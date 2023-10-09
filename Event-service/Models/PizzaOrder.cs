namespace Event_service.Models
{
    public record PizzaOrder
    {
        public int TableNumber { get; set; }
        public string[]? PizzaNumbers { get; set; }

    }
}
