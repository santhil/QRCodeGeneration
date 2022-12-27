using Dttl.Qr.Data;
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
            var result = await _dbContext._qrCode.ToListAsync();
            if (result == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetQRCodeListById")]
        public async Task<IActionResult> GetQRCodeListById(int Id)
        {
            var result = await _dbContext._qrCode.FirstOrDefaultAsync(m => m.QRCodeId == Id);
            if (result == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost("AddQRCodes")]
        public async Task<IActionResult> AddQRCodes([FromBody] QrCode qrCode)
        {
            if (ModelState.IsValid)
            {
                await _dbContext.AddAsync(qrCode);
                await _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, qrCode);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateQRCode")]
        public async Task<IActionResult> UpdateQRCode([FromBody] QrCode qRCode)
        {
            if (ModelState.IsValid)
            {
                _dbContext._qrCode.Update(qRCode);
                await _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, qRCode);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("DeleteQRCodes")]
        public async Task<IActionResult> DeleteQRCodes(int Id)
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
                return StatusCode(StatusCodes.Status200OK, result);
            }
        }
    }
}