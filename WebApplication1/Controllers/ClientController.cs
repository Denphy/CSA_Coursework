using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models;
using WebApplication1.Data.Services;
using WebApplication1.Data.DTOs;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClientController : ControllerBase
    {
        private readonly ClientService _executor;

        public ClientController(ClientService executor)
        {
            _executor = executor;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClient()
        {
            return await _executor.GetClients();
        }

        [HttpGet("/incomplete_client")]
        public async Task<ActionResult<IEnumerable<IncompleteClientDTO>>> GetClientIncomplete()
        {
            return await _executor.GetClientsIncomplete();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var Client = await _executor.GetClient(id);

            return Client;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClientDTO>> PutClient(int id, [FromBody] ClientDTO Client)
        {
            var result = await _executor.UpdateClient(id,Client);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ClientDTO>> PostClient([FromBody] ClientDTO Client)
        {
            var result = await _executor.AddClient(Client);
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var Client = await _executor.DeleteClient(id);
            if (Client)
            {
                return Ok();
            }
            return BadRequest();
        }

    }

}
