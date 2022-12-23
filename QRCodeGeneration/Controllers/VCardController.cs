using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCodeGeneration.Data;
using QRCodeGeneration.Model;

namespace QRCodeGeneration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VCardController : ControllerBase
    {
        private readonly DbContextClass _dbContext;
        public VCardController(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetVCardList")]
        public async Task<IActionResult> GetVCardList()
        {
            try
            {
                var result = await _dbContext.vCardDetails.ToListAsync();
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
                var result = await _dbContext.vCardDetails.FirstOrDefaultAsync(m => m.VId == Id);
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
        public async Task<IActionResult> AddVCard([FromBody] VCardDetails vCardDetails)
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
        public async Task<IActionResult> UpdateVCarde([FromBody] VCardDetails vCardDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dbContext.vCardDetails.Update(vCardDetails);
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
                var result = await _dbContext.vCardDetails.FindAsync(Id);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    _dbContext.vCardDetails.Remove(result);
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
