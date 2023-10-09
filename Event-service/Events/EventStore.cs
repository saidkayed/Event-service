using Event_service.Events.Interface;

namespace Event_service.Events
{
    public class EventStore : IEventStore
    {

        private static long currentSequenceNumber = 0;

        private static readonly IList<OrderEvent> Database = new List<OrderEvent>();
        public IEnumerable<OrderEvent> GetEvents(int start, int end)
        {
            return Database.Where(x => x.SequenceNumber >= start && x.SequenceNumber <= end);
        }

        public void RaiseEvent(string name, object content)
        {
            var SequenceNumber = Interlocked.Increment(ref currentSequenceNumber);

            var orderEvent = new OrderEvent
            {
                SequenceNumber = SequenceNumber,
                Name = name, 
                Timestamp = DateTime.UtcNow,
                Content = content
            };


            Database.Add(orderEvent);
        }
    }
}
