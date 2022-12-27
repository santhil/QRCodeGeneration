using Dttl.Qr.Model;
using System.Text;

namespace Dttl.Qr.Util
{
    public static class VCardUtil
    {
        public static string GetVCard(VCardQRCode vCardModel)
        {
            var builder = new StringBuilder();
            builder.AppendLine("BEGIN:VCARD").AppendLine("VERSION:2.1");

            // Name
            builder.Append("N:").Append(vCardModel.LastName)
              .Append(";").AppendLine(vCardModel.FirstName);

            // Full name
            builder.Append("FN:").Append(vCardModel.FirstName)
              .Append(" ").AppendLine(vCardModel.LastName);

            // Other data
            builder.Append("ORG:").AppendLine(vCardModel.CompanyName);
            builder.Append("TITLE:").AppendLine(vCardModel.Designation);
            builder.Append("TEL;WORK;VOICE:").AppendLine(vCardModel.MobileNo);
            builder.Append("TEL;CELL;VOICE:").AppendLine(vCardModel.MobileNo);
            builder.AppendLine("URL;").AppendLine(vCardModel.Website);
            builder.Append("EMAIL;PREF;INTERNET:").AppendLine(vCardModel.EmailId);
            builder.Append("PHOTO;ENCODING=BASE64;TYPE=JPEG:").AppendLine(Convert.ToBase64String(vCardModel.UploadImage));

            builder.AppendLine("END:VCARD");
            return builder.ToString();
        }
    }
}