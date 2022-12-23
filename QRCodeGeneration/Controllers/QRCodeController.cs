using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCodeGeneration.Data;
using QRCodeGeneration.Model;

namespace QRCodeGeneration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRCodeController : ControllerBase
    {
        private readonly DbContextClass _dbContext;
        public QRCodeController(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetQRCodeList")]
        public async Task<IActionResult> GetQRCodeList()
        {
            try
            {
                var result = await _dbContext.qrCode.ToListAsync();
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
                var result = await _dbContext.qrCode.FirstOrDefaultAsync(m => m.QRCodeId == Id);
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
        public async Task<IActionResult> AddQRCodes([FromBody] QrCode QRCodes)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _dbContext.AddAsync(QRCodes);
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
        [HttpPut("UpdateQReDetails")]
        public async Task<IActionResult> UpdateQReDetails([FromBody] QrCode qRCode)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dbContext.qrCode.Update(qRCode);
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
                var result = await _dbContext.qrCode.FindAsync(Id);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    _dbContext.qrCode.Remove(result);
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
