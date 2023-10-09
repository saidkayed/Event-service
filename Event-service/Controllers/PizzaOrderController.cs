using Event_service.Events.Interface;
using Event_service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event_service.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PizzaOrderController : ControllerBase
    {
        private readonly IEventStore eventStore;
        private static readonly Dictionary<int, PizzaOrder> pizzaOrders = new();


        public PizzaOrderController(IEventStore eventStore)
        {
            this.eventStore = eventStore;
        }

        [HttpPost]
        public ActionResult<PizzaOrder> CreateOrder([FromBody]PizzaOrder order)
        {
            if (order.TableNumber < 0 || order.PizzaNumbers == null || order.PizzaNumbers.Length == 0)
            {
                return BadRequest("Invalid order");
            }

            eventStore.RaiseEvent("OrderCreated", order);
            pizzaOrders.Add(order.TableNumber, order);
            return Ok(order);
        }


    }
}
