using static System.Net.Mime.MediaTypeNames;
using System.Numerics;
using System.Reflection;
using System.Text;
using Dttl.Qr.Model;

namespace Dttl.Qr.Util
{
    public class VCardUtil
    {
        public string GetVcardXml(VCardQRCode vCardQRCode)
        {
            return XmlUtil.SerializeObject(vCardQRCode);
        }
        public  vcard GetVCard(VCardQRCode vCardQRCode)
        {
           vcard _vcard = new vcard();
            _vcard.fn = vCardQRCode.FirstName;
            _vcard.org = new vcardOrg() { organizationname = vCardQRCode.CompanyName };
          
            

            return _vcard;

        }
    }
}
