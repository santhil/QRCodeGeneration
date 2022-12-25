using QRCodeGeneration.Model;

namespace QRCodeGeneration.Repositories
{
    public interface IQRCodeService
    {
        public Task<List<QrCode>> GetQRCodeList();
        public Task<QrCode> GetQRCodeListById(int Id);
        public Task<int> AddQRCodes(QrCode qRCode);
        public Task<int> UpdateQRCode(QrCode qRCode);
        public Task<int> DeleteQRCodes(int Id);
    }
}
