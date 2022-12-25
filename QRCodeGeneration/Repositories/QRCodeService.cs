using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QRCodeGeneration.Data;
using QRCodeGeneration.Model;
using System;
using System.Reflection.Emit;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace QRCodeGeneration.Repositories
{
    public class QRCodeService : IQRCodeService
    {
        private readonly DbContextClass _dbContext;
        public QRCodeService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<QrCode>> GetQRCodeList()
        {
            try
            {
                return await _dbContext._qrCode.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<QrCode> GetQRCodeListById(int Id)
        {
            try
            {
                var product = await _dbContext._qrCode.FirstOrDefaultAsync(m => m.QRCodeId == Id);
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
        public async Task<int> AddQRCodes(QrCode qRCode)
        {
            try
            {
                await _dbContext.AddAsync(qRCode);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> UpdateQRCode(QrCode qRCode)
        {
            try
            {
                _dbContext._qrCode.Update(qRCode);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> DeleteQRCode(int id)
        {
            var result = await _dbContext._qrCode.FirstOrDefaultAsync(e => e.QRCodeId == id);
            if (result != null)
            {
                _dbContext._qrCode.Remove(result);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }
    }
}
