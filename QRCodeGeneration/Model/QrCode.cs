using System.ComponentModel.DataAnnotations;

namespace QRCodeGeneration.Model
{
    public class QrCode
    {
        [Key]
        public int QRCodeId { get; set; }
        public string? QRName { get; set; }
        public bool Static { get; set; }
        public bool Dynamic { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
