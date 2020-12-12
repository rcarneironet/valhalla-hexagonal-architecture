using Microsoft.AspNetCore.Mvc;

namespace Valhalla.Ports.OrderConsumerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersConsumerController : Controller
    {

        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
