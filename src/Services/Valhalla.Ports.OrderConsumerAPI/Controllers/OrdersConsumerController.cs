﻿using Microsoft.AspNetCore.Mvc;

namespace Valhalla.Ports.OrderConsumerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersConsumerController : Controller
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
