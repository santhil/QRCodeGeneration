using Dttl.Qr.Data;
using Dttl.Qr.Model;
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
            var result = await _dbContext._uRLQRCodes.ToListAsync();
            if (result == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetURLQRCodeListById")]
        public async Task<IActionResult> GetURLQRCodeListById(int Id)
        {
            var result = await _dbContext._uRLQRCodes.FirstOrDefaultAsync(m => m.URLId == Id);
            if (result == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost("AddURLQRCode")]
        public async Task<IActionResult> AddURLQRCode([FromBody] URLQRCode uRLQRCode)
        {
            if (ModelState.IsValid)
            {
                await _dbContext.AddAsync(uRLQRCode);
                await _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, uRLQRCode);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateURLQRCode")]
        public async Task<IActionResult> UpdateURLQRCode([FromBody] URLQRCode uRLQRCode)
        {
            if (ModelState.IsValid)
            {
                _dbContext._uRLQRCodes.Update(uRLQRCode);
                await _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, uRLQRCode);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteURLQRCode")]
        public async Task<IActionResult> DeleteURLQRCode(int Id)
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
                return StatusCode(StatusCodes.Status200OK, result);
            }
        }
    }
}