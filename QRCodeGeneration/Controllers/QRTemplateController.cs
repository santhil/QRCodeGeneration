using Dttl.Qr.Data;
using Dttl.Qr.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dttl.Qr.Service
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRTemplateController : BaseController
    {
        private readonly DbContextClass _dbContext;
        public QRTemplateController(DbContextClass dbContext, ILogger<QRTemplateController> logger) : base(logger)
        {
            _dbContext = dbContext;
        }
        [HttpGet("GetQRTemplateList")]
        public async Task<IActionResult> GetQRTemplateList()
        {
            var result = await _dbContext._qRTemplates.ToListAsync();
            if (result == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetQRTemplateListById")]
        public async Task<IActionResult> GetQRTemplateListById(int Id)
        {
            var result = await _dbContext._qRTemplates.FirstOrDefaultAsync(m => m.TemplateId == Id);
            if (result == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost("AddQRTemplate")]
        public async Task<IActionResult> AddQRTemplate([FromBody] QRTemplate qRTemplate)
        {
            if (ModelState.IsValid)
            {
                await _dbContext.AddAsync(qRTemplate);
                await _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, qRTemplate);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateQRTemplate")]
        public async Task<IActionResult> UpdateQRTemplate([FromBody] QRTemplate qRTemplate)
        {
            if (ModelState.IsValid)
            {
                _dbContext._qRTemplates.Update(qRTemplate);
                await _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, qRTemplate);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteQRTemplate")]
        public async Task<IActionResult> DeleteQRTemplate(int Id)
        {
            var result = await _dbContext._qRTemplates.FindAsync(Id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                _dbContext._qRTemplates.Remove(result);
                await _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, result);
            }
        }
    }
}