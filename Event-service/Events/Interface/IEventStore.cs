namespace Event_service.Events.Interface
{
    public interface IEventStore
    {

        void RaiseEvent(string name, object content);

        IEnumerable<OrderEvent> GetEvents(int start, int end);
    }
}
