using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models;
using WebApplication1.Data.Services;
using WebApplication1.Data.DTOs;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ParcelController : ControllerBase
    {
        private readonly ParcelService _executor;

        public ParcelController(ParcelService executor)
        {
            _executor = executor;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parcel>>> GetParcel()
        {
            return await _executor.GetParcels();
        }

        [HttpGet("/incomplete_parcel")]
        public async Task<ActionResult<IEnumerable<IncompleteParcelDTO>>> GetParcelIncomplete()
        {
            return await _executor.GetParcelsIncomplete();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Parcel>> GetParcel(int id)
        {
            var Parcel = await _executor.GetParcel(id);

            if (Parcel == null)
            {
                return new Parcel();
            }

            return Parcel;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ParcelDTO>> PutParcel(int id, [FromBody] ParcelDTO Parcel)
        {
            var result = await _executor.UpdateParcel(id,Parcel);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ParcelDTO>> PostParcel([FromBody] ParcelDTO Parcel)
        {
            var result = await _executor.AddParcel(Parcel);
            if (result == null)
            {
                BadRequest();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParcel(int id)
        {
            var Parcel = await _executor.DeleteParcel(id);
            if (Parcel)
            {
                return Ok();
            }
            return BadRequest();
        }

    }

}
