using Dttl.Qr.Data;
using Dttl.Qr.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dttl.Qr.Service
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
            var result = await _dbContext._qRDetails.ToListAsync();
            if (result == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetQRDetailListById")]
        public async Task<IActionResult> GetQRDetailListById(int Id)
        {
            var result = await _dbContext._qRDetails.FirstOrDefaultAsync(m => m.QRDetailId == Id);
            if (result == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost("AddQRDetails")]
        public async Task<IActionResult> AddQRDetails([FromBody] QRDetails qRDetails)
        {
            if (ModelState.IsValid)
            {
                await _dbContext.AddAsync(qRDetails);
                await _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, qRDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateQReDetails")]
        public async Task<IActionResult> UpdateQReDetails([FromBody] QRDetails qRDetails)
        {
            if (ModelState.IsValid)
            {
                _dbContext._qRDetails.Update(qRDetails);
                await _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, qRDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteQRDetails")]
        public async Task<IActionResult> DeleteQRDetails(int Id)
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
                return StatusCode(StatusCodes.Status200OK, result);
            }
        }
    }
}