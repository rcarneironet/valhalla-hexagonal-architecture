using Microsoft.AspNetCore.Mvc;
using System;
using Valhalla.Modules.Application.Commands.PlaceOrder;
using Valhalla.Modules.Application.Inputs.Order;

namespace Valhalla.Ports.OrderAPI.Controllers
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
            var order = _placeOrderService.Execute(input);            
            Console.WriteLine("Ordem criada: " + order);//apenas para efeito de demo
            return Ok(new { Message = "Ordem criada: " + order }); ;

        }
    }
}
