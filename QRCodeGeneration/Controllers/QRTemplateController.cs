using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCodeGeneration.Data;
using QRCodeGeneration.Model;

namespace QRCodeGeneration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRTemplateController : ControllerBase
    {
        private readonly DbContextClass _dbContext;
        private readonly ILogger<QRTemplateController> _logger;
        public QRTemplateController(DbContextClass dbContext, ILogger<QRTemplateController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet("GetQRTemplateList")]
        public async Task<IActionResult> GetQRTemplateList()
        {
            try
            {
                var result = await _dbContext._qRTemplates.ToListAsync();
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
        [HttpGet("GetQRTemplateListById")]
        public async Task<IActionResult> GetQRTemplateListById(int Id)
        {
            try
            {
                var result = await _dbContext._qRTemplates.FirstOrDefaultAsync(m => m.TemplateId == Id);
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

        [HttpPost("AddQRTemplate")]
        public async Task<IActionResult> AddQRTemplate([FromBody] QRTemplate qRTemplate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _dbContext.AddAsync(qRTemplate);
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
        [HttpPut("UpdateQRTemplate")]
        public async Task<IActionResult> UpdateQRTemplate([FromBody] QRTemplate qRTemplate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dbContext._qRTemplates.Update(qRTemplate);
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

        [HttpDelete("DeleteQRTemplate")]
        public async Task<IActionResult> DeleteQRTemplate(int Id)
        {
            try
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
