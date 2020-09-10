using Microsoft.AspNetCore.Mvc;
using System;
using Valhalla.Modules.Application.Commands.PlaceOrder;
using Valhalla.Modules.Application.Inputs.Order;

namespace Valhalla.Modules.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {

        private readonly IPlaceOrderUseCase _placeOrderService;
        public OrdersController(IPlaceOrderUseCase placeOrderService)
        {
            _placeOrderService = placeOrderService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] PlaceOrderInput input)
        {
            Guid orderId = _placeOrderService.Execute(input);

            if (orderId == Guid.Empty)
                return new NoContentResult();

            return Accepted();

        }
    }
}
