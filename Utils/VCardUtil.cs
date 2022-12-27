using Dttl.Qr.Model;
using System.Numerics;
using System.Reflection;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Dttl.Qr.Util
{
    public static class VCardUtil
    {
        public static string GetVCard(VCardQRCode vCardModel)
        {
            var builder = new StringBuilder();
            builder.AppendLine("BEGIN:VCARD");
            builder.AppendLine("VERSION:2.1");

            // Name        
            builder.Append("N:").Append(vCardModel.LastName)
              .Append(";").AppendLine(vCardModel.FirstName);

            // Full name        
            builder.Append("FN:").Append(vCardModel.FirstName)
              .Append(" ").AppendLine(vCardModel.LastName);

            // Address        
            //builder.Append("ADR;HOME;PREF:;;").Append(StreetAddress)
            //  .Append(";").Append(City).Append(";")
            //  .Append(Zip).Append(";").AppendLine(CountryName);

            // Other data        
            builder.Append("ORG:").AppendLine(vCardModel.CompanyName);
            builder.Append("TITLE:").AppendLine(vCardModel.Designation);
            builder.Append("TEL;WORK;VOICE:").AppendLine(vCardModel.MobileNo);
            builder.Append("TEL;CELL;VOICE:").AppendLine(vCardModel.MobileNo);
            builder.Append("URL:").AppendLine(vCardModel.Website);
            builder.Append("EMAIL;PREF;INTERNET:").AppendLine(vCardModel.EmailId);

            // Image        
            if (vCardModel.UploadImage != null)
            {
                builder.AppendLine("PHOTO;ENCODING=BASE64;TYPE=JPEG:");
                builder.AppendLine(Convert.ToBase64String(vCardModel.UploadImage));
                builder.AppendLine(string.Empty);
            }
            builder.AppendLine("END:VCARD");
            return builder.ToString();
        }
    }
}