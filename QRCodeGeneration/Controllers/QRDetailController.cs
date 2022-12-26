using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCodeGeneration.Data;
using QRCodeGeneration.Model;

namespace QRCodeGeneration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRDetailController : BaseController
    {
        private readonly DbContextClass _dbContext;
        public QRDetailController(DbContextClass dbContext, ILogger<QRDetailController> logger) : base(logger)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetQRDetailList")]
        public async Task<IActionResult> GetQRDetailList()
        {
            try
            {
                var result = await _dbContext._qRDetails.ToListAsync();
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
        [HttpGet("GetQRDetailListById")]
        public async Task<IActionResult> GetQRDetailListById(int Id)
        {
            try
            {
                var result = await _dbContext._qRDetails.FirstOrDefaultAsync(m => m.QRDetailId == Id);
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

        [HttpPost("AddQRDetails")]
        public async Task<IActionResult> AddQRDetails([FromBody] QRDetails qRDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _dbContext.AddAsync(qRDetails);
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
        public async Task<IActionResult> UpdateQReDetails([FromBody] QRDetails qRCode)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dbContext._qRDetails.Update(qRCode);
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

        [HttpDelete("DeleteQRDetails")]
        public async Task<IActionResult> DeleteQRDetails(int Id)
        {
            try
            {
                var result = await _dbContext._qRDetails.FindAsync(Id);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    _dbContext._qRDetails.Remove(result);
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
