using Dttl.Qr.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace Dttl.Qr.Service
{
    [Route("api/[controller]")]
    [ApiController]
    public class URLController : BaseController
    {
        private readonly DbContextClass _dbContext;
        public URLController(DbContextClass dbContext, ILogger<URLController> logger) : base(logger)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetURLQRCodeList")]
        public async Task<IActionResult> GetURLQRCodelList()
        {
            try
            {
                var result = await _dbContext._uRLQRCodes.ToListAsync();
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
        [HttpGet("GetURLQRCodeListById")]
        public async Task<IActionResult> GetURLQRCodeListById(int Id)
        {
            try
            {
                var result = await _dbContext._uRLQRCodes.FirstOrDefaultAsync(m => m.URLId == Id);
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

        [HttpPost("AddURLQRCode")]
        public async Task<IActionResult> AddURLQRCode([FromBody] URLQRCode uRLQRCode)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _dbContext.AddAsync(uRLQRCode);
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
        [HttpPut("UpdateURLQRCode")]
        public async Task<IActionResult> UpdateURLQRCode([FromBody] URLQRCode uRLQRCode)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dbContext._uRLQRCodes.Update(uRLQRCode);
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

        [HttpDelete("DeleteURLQRCode")]
        public async Task<IActionResult> DeleteURLQRCode(int Id)
        {
            try
            {
                var result = await _dbContext._uRLQRCodes.FindAsync(Id);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    _dbContext._uRLQRCodes.Remove(result);
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
