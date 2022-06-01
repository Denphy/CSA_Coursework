using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models;
using WebApplication1.Data.Services;
using WebApplication1.Data.DTOs;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReceiverController : ControllerBase
    {
        private readonly ReceiverService _executor;

        public ReceiverController(ReceiverService executor)
        {
            _executor = executor;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receiver>>> GetReceiver()
        {
            return await _executor.GetReceivers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Receiver>> GetReceiver(int id)
        {
            var receiver = await _executor.GetReceiver(id);

            if (receiver == null)
            {
                return NotFound();
            }

            return receiver;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClientSplitDTO>> PutReceiver(int id, [FromBody] ClientSplitDTO receiver)
        {
            var result = await _executor.UpdateReceiver(id, receiver);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ClientSplitDTO>> PostReceiver([FromBody] ClientSplitDTO receiver)
        {
            var result = await _executor.AddReceiver(receiver);
            if (result == null)
            {
                BadRequest();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceiver(int id)
        {
            var receiver = await _executor.DeleteReceiver(id);
            if (receiver)
            {
                return Ok();
            }
            return BadRequest();
        }

    }

}
