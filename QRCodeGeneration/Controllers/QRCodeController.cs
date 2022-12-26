using Dttl.Qr.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace Dttl.Qr.Service
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRCodeController : BaseController
    {
        private readonly DbContextClass _dbContext;
        public QRCodeController(DbContextClass dbContext, ILogger<QRCodeController> logger) : base(logger)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetQRCodeList")]
        public async Task<IActionResult> GetQRCodeList()
        {
            try
            {
                var result = await _dbContext._qrCode.ToListAsync();
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
        [HttpGet("GetQRCodeListById")]
        public async Task<IActionResult> GetQRCodeListById(int Id)
        {
            try
            {
                var result = await _dbContext._qrCode.FirstOrDefaultAsync(m => m.QRCodeId == Id);
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

        [HttpPost("AddQRCodes")]
        public async Task<IActionResult> AddQRCodes([FromBody] QrCode qrCode)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _dbContext.AddAsync(qrCode);
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
        [HttpPut("UpdateQRCode")]
        public async Task<IActionResult> UpdateQRCode([FromBody] QrCode qRCode)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dbContext._qrCode.Update(qRCode);
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

        [HttpDelete("DeleteQRCodes")]
        public async Task<IActionResult> DeleteQRCodes(int Id)
        {
            try
            {
                var result = await _dbContext._qrCode.FindAsync(Id);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    _dbContext._qrCode.Remove(result);
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
