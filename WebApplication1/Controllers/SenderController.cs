using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models;
using WebApplication1.Data.Services;
using WebApplication1.Data.DTOs;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SenderController : ControllerBase
    {
        private readonly SenderService _executor;

        public SenderController(SenderService executor)
        {
            _executor = executor;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sender>>> GetSender()
        {
            return await _executor.GetSenders();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sender>> GetSender(int id)
        {
            var Sender = await _executor.GetSender(id);

            if (Sender == null)
            {
                return NotFound();
            }

            return Sender;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClientSplitDTO>> PutSender(int id, [FromBody] ClientSplitDTO sender)
        {
            var result = await _executor.UpdateSender(id, sender);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ClientSplitDTO>> PostSender([FromBody] ClientSplitDTO sender)
        {
            var result = await _executor.AddSender(sender);
            if (result == null)
            {
                BadRequest();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSender(int id)
        {
            var sender = await _executor.DeleteSender(id);
            if (sender)
            {
                return Ok();
            }
            return BadRequest();
        }

    }

}
