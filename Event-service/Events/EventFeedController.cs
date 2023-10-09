using Event_service.Events.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Event_service.Events
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventFeedController : ControllerBase
    {
        private readonly IEventStore eventStore;

        public EventFeedController(IEventStore eventStore)
        {
            this.eventStore = eventStore;
        }

        [HttpGet]
        public ActionResult<OrderEvent[]> GetEvents([FromQuery] int start, [FromQuery] int end)
        {
            if (start < 0 || end < start)
            {
                return BadRequest("Invalid start and end values.");
            }

            var events = this.eventStore.GetEvents(start, end).ToArray();

            if (events.Length == 0)
            {
                return NoContent();
            }

            return Ok(events);

        }

    }
}
