using Dttl.Qr.Data;
using Dttl.Qr.Model;
using Microsoft.AspNetCore.Mvc;

namespace Dttl.Qr.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly DbContextClass _dbContext;

        public SearchController(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetSearchByFilter")]
        public async Task<IActionResult> GetSearchByFilter([FromBody] SearchFilter searchFilter)
        {
            if (searchFilter.FromDate.ToString() != "" && searchFilter.ToDate.ToString() != "" && searchFilter.TemplateName != "")
            {
                var result = (from _template in _dbContext._qRTemplates
                              where
                              (_template.TemplateName.Contains("" + searchFilter.TemplateName + "")) &&
                              (_template.CreatedDate >= Convert.ToDateTime(searchFilter.FromDate) && _template.CreatedDate <= Convert.ToDateTime(searchFilter.ToDate.ToString()))
                              //EF.Functions.Like(_template.TemplateName, "%" + searchFilter.TemplateName + "%")

                              select new
                              {
                                  _template.TemplateName,
                                  _template.ForeColor,
                                  _template.BackgroundColor,
                                  _template.Height,
                                  _template.Width
                              }).ToList();
                return Ok(result);
            }
            else if (searchFilter.FromDate.ToString() == "" && searchFilter.ToDate.ToString() == "" && searchFilter.TemplateName != "")
            {
                var result = (from _template in _dbContext._qRTemplates
                              where
                              _template.TemplateName.Contains("" + searchFilter.TemplateName + "")
                              select new
                              {
                                  _template.TemplateName,
                                  _template.ForeColor,
                                  _template.BackgroundColor,
                                  _template.Height,
                                  _template.Width
                              }).ToList();
                return Ok(result);
            }
            else if (searchFilter.FromDate.ToString() != "" && searchFilter.ToDate.ToString() != "" && searchFilter.TemplateName == "")
            {
                var result = (from _template in _dbContext._qRTemplates
                              where
                             (_template.CreatedDate >= Convert.ToDateTime(searchFilter.FromDate) && _template.CreatedDate <= Convert.ToDateTime(searchFilter.ToDate.ToString()))
                              select new
                              {
                                  _template.TemplateName,
                                  _template.ForeColor,
                                  _template.BackgroundColor,
                                  _template.Height,
                                  _template.Width
                              }).ToList();
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}