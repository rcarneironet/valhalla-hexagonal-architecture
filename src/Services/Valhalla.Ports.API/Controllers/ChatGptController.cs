using Microsoft.AspNetCore.Mvc;

namespace Valhalla.Ports.OrderAPI.Controllers
{
    public class ChatGptController : Controller
    {
        [HttpGet]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
