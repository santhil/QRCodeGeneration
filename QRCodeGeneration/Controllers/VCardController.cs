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
            try
            {
                var result = await _dbContext._vCardQRCodes.ToListAsync();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("GetVCardById")]
        public async Task<IActionResult> GetVCardById(int Id)
        {
            try
            {
                var result = await _dbContext._vCardQRCodes.FirstOrDefaultAsync(m => m.VCardId == Id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("AddVCard")]
        public async Task<IActionResult> AddVCard([FromBody] VCardQRCode vCardDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _dbContext.AddAsync(vCardDetails);
                    await _dbContext.SaveChangesAsync();
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut("UpdateVCard")]
        public async Task<IActionResult> UpdateVCarde([FromBody] VCardQRCode vCardDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dbContext._vCardQRCodes.Update(vCardDetails);
                    await _dbContext.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteVCard")]
        public async Task<IActionResult> DeleteVCard(int Id)
        {
            try
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
                    return Ok();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
