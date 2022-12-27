using Dttl.Qr.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dttl.Qr.Repository
{
    public interface IQRCodeService
    {
        public Task<List<QrCode>> GetQRCodeList();
        public Task<QrCode> GetQRCodeListById(int Id);
        public Task<QrCode> AddQRCodes(QrCode qRCode);
        public Task<QrCode> UpdateQRCode(QrCode qRCode);
        public Task<QrCode> DeleteQRCodes(int Id);
    }
}
