using System.ComponentModel.DataAnnotations;

namespace QRCodeGeneration.Model
{
    public class VCardDetails
    {
        [Key]
        public int VId { get; set; }
        public int QRDetailId { get; set; }
        public string? Title { get; set; }
        public string? EmployeeCode { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public byte[]? UploadImage { get; set; }
        public string? Designation { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailId { get; set; }
        public string? CompanyName { get; set; }
        public string? Website { get; set; }
        public string? PersonalLinks { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
