using Dttl.Qr.Model;
using System.Text;

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
            builder.AppendLine("N:" + vCardModel.LastName + ";" + vCardModel.FirstName);
            // Full name
            builder.AppendLine("FN:" + vCardModel.FirstName);
            // Address
            /*
            builder.Append("ADR;HOME;PREF:;;");
            builder.Append(StreetAddress + ";");
            builder.Append(City + ";;");
            builder.Append(Zip + ";");
            builder.AppendLine(CountryName);*/
            // Other data
            builder.AppendLine("ORG:" + vCardModel.CompanyName);
            builder.AppendLine("TITLE:" + vCardModel.Designation);
            builder.AppendLine("TEL;HOME;VOICE:" + vCardModel.MobileNo);
            builder.AppendLine("TEL;CELL;VOICE:" + vCardModel.MobileNo);
            builder.AppendLine("URL;" + vCardModel.PersonalLinks);
            builder.AppendLine("EMAIL;PREF;INTERNET:" + vCardModel.EmailId);
            //  builder.AppendLine("PHOTO;ENCODING=BASE64;TYPE=JPEG:" + Convert.ToBase64String(Image));

            builder.AppendLine("END:VCARD");
            return builder.ToString();
        }
    }
}