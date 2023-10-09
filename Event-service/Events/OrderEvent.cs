namespace Event_service.Events
{
    public record OrderEvent
    {
        public long SequenceNumber { get; set; }
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }

        public object Content { get; set; }
    }
}
