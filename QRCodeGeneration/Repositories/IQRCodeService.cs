using QRCodeGeneration.Model;

namespace QRCodeGeneration.Repositories
{
    public interface IQRCodeService
    {
        public Task<List<QRDetails>> GetQRCodeData();
        public Task<IEnumerable<QRDetails>> GetQRCodeDataById(int Id);
        public Task<int> AddQRCode(QRDetails qRCode);
        public Task<int> UpdateQRCode(QRDetails qRCode);
        public Task<int> DeleteQRCode(int Id);
    }
}
