using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QRCodeGeneration.Model
{
    [Table("URLQRCode")]
    public class URLQRCode
    {
        [Key]
        public int URLId { get; set; }
        public int QRCodeId { get; set; }
        public string? Url { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
