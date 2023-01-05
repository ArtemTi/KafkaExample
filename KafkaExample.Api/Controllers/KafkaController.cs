using KafkaExample.App;
using KafkaExample.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KafkaExample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KafkaController : ControllerBase
    {
        private readonly UserDataService _userService;

        public KafkaController(UserDataService userService)
        {
            _userService = userService;
        }

        [HttpPost("produceAsync")]
        public async Task<IActionResult> ProduceAsync(UserData data)
        {
            await _userService.ProcessDataAsync(data);

            return Ok();
        }

        [HttpPost("produce")]
        public IActionResult Produce(UserData data)
        {
            _userService.ProcessData(data);

            return Ok();
        }
    }
}
