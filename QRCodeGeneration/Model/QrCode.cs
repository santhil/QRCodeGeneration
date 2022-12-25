using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QRCodeGeneration.Model
{
    [Table("QRCode")]
    public class QrCode
    {
        [Key]
        public int QRCodeId { get; set; }
        public int TemplateId { get; set; }

        [Required(ErrorMessage = "QR Name is required")]
        //[StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string? QRName { get; set; }
        public bool Static { get; set; }
        public bool Dynamic { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? ExpiryDate { get; }
    }
}
