using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QRCodeGeneration.Data;
using QRCodeGeneration.Model;

namespace QRCodeGeneration.Repositories
{
    public class QRCodeService : IQRCodeService
    {
        private readonly DbContextClass _dbContext;
        public QRCodeService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<QRDetails>> GetQRCodeData()
        {
            try
            {
                return await _dbContext.qRDetails.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<QRDetails> GetQRCodeDataById(int QrCodeId)
        {
            try
            {
                var product = await _dbContext.qRDetails.FirstOrDefaultAsync(m => m.QRDetailId == QrCodeId);
                return product;
                //if (product == null)
                //    return NotFound();
                //return Ok(product);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> AddQRCode(QRDetails qRDetails)
        {
            try
            {
                _dbContext.Add(qRDetails);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateQRCode(QRDetails qRDetails)
        {
            try
            {
                var parameter = new List<SqlParameter>();
                parameter.Add(new SqlParameter("@QRDetailId", qRDetails.QRDetailId));
                parameter.Add(new SqlParameter("@QRCodeId", qRDetails.QRCodeId));
                parameter.Add(new SqlParameter("@TemplateId", qRDetails.TemplateId));
                parameter.Add(new SqlParameter("@QRName", qRDetails.QRName));
                parameter.Add(new SqlParameter("@QRImage", qRDetails.QRImage));
                parameter.Add(new SqlParameter("@TargetUrl", qRDetails.TargetUrl));
                parameter.Add(new SqlParameter("@FormatType", qRDetails.FormatType));
                parameter.Add(new SqlParameter("@CreatedBy", qRDetails.CreatedBy));
                parameter.Add(new SqlParameter("@CreatedDate", qRDetails.CreatedDate));
                parameter.Add(new SqlParameter("@ModifiedBy", qRDetails.ModifiedBy));
                parameter.Add(new SqlParameter("@ModifiedDate", qRDetails.ModifiedDate));
                parameter.Add(new SqlParameter("@IsActive", qRDetails.IsActive));
                parameter.Add(new SqlParameter("@ExpiryDate", qRDetails.ExpiryDate));
                parameter.Add(new SqlParameter("@Type", "QRCODE_UPDATE"));

                var result = await Task.Run(() => _dbContext.Database
               .ExecuteSqlRawAsync(@"exec SP_QRCodeAdd @QRDetailId,@QRCodeId,@TemplateId,@QRName,@QRImage,@TargetUrl,@FormatType,@CreatedBy,@CreatedDate,@ModifiedBy,@ModifiedDate,@IsActive,@ExpiryDate,@Type", parameter.ToArray()));
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteQRCode(int id)
        {
            try
            {
                var result = await _dbContext.qRDetails.FindAsync(id);
                _dbContext.qRDetails.Remove(result);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
