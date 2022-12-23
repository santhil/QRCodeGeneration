using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace QRCodeGeneration.Model
{
    public class QRDetails
    {
        [Key]
        public int QRDetailId { get; set; }
        public int QRCodeId { get; set; }
        public int TemplateId { get; set; }
        public string? QRName { get; set; }
        public byte[]? QRImage { get; set; }
        public string? TargetUrl { get; set; }
        public string? FormatType { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
