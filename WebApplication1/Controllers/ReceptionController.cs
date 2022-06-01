using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models;
using WebApplication1.Data.Services;
using WebApplication1.Data.DTOs;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReceptionController : ControllerBase
    {
        private readonly ReceptionService _executor;

        public ReceptionController(ReceptionService executor)
        {
            _executor = executor;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reception>>> GetReception()
        {
            return await _executor.GetReceptions();
        }

        [HttpGet("/incomplete_reception")]
        public async Task<ActionResult<IEnumerable<IncompleteReceptionDTO>>> GetReceptionIncomplete()
        {
            return await _executor.GetReceptionsIncomplete();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reception>> GetReception(int id)
        {
            var Reception = await _executor.GetReception(id);

            if (Reception == null)
            {
                return NotFound();
            }

            return Reception;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReceptionDTO>> PutReception(int id, [FromBody] ReceptionDTO Reception)
        {
            var result = await _executor.UpdateReception(id, Reception);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ReceptionDTO>> PostReception([FromBody] ReceptionDTO Reception)
        {
            var result = await _executor.AddReception(Reception);
            if (result == null)
            {
                BadRequest();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReception(int id)
        {
            var Reception = await _executor.DeleteReception(id);
            if (Reception)
            {
                return Ok();
            }
            return BadRequest();
        }

    }

}
