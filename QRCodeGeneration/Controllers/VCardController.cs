using Dttl.Qr.Data;
using Dttl.Qr.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dttl.Qr.Service
{
    [Route("api/[controller]")]
    [ApiController]
    public class VCardController : BaseController
    {
        private readonly DbContextClass _dbContext;
        public VCardController(DbContextClass dbContext, ILogger<VCardController> logger) : base(logger)
        {
            _dbContext = dbContext;
        }
        [HttpGet("GetVCardList")]
        public async Task<IActionResult> GetVCardList()
        {
            var result = await _dbContext._vCardQRCodes.ToListAsync();
            if (result == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetVCardById")]
        public async Task<IActionResult> GetVCardById(int Id)
        {
            var result = await _dbContext._vCardQRCodes.FirstOrDefaultAsync(m => m.VCardId == Id);
            if (result == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost("AddVCard")]
        public async Task<IActionResult> AddVCard([FromBody] VCardQRCode vCardDetails)
        {
            if (ModelState.IsValid)
            {
                await _dbContext.AddAsync(vCardDetails);
                await _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, vCardDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateVCard")]
        public async Task<IActionResult> UpdateVCarde([FromBody] VCardQRCode vCardDetails)
        {
            if (ModelState.IsValid)
            {
                _dbContext._vCardQRCodes.Update(vCardDetails);
                await _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, vCardDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteVCard")]
        public async Task<IActionResult> DeleteVCard(int Id)
        {
            var result = await _dbContext._vCardQRCodes.FindAsync(Id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                _dbContext._vCardQRCodes.Remove(result);
                await _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, result);
            }
        }
    }
}