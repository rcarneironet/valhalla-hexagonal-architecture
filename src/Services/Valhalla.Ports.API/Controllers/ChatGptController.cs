using Microsoft.AspNetCore.Mvc;
using Valhalla.Modules.Application.UseCases.ChatGpt;

namespace Valhalla.Ports.OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGptController : Controller
    {

        private readonly IChatGptUseCase _chatGptService;

        public ChatGptController(IChatGptUseCase chatGptService)
        {
            _chatGptService = chatGptService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Get(string text)
        {
            var responseText = _chatGptService.Execute(text);
            return Ok(responseText);
        }
    }
}
