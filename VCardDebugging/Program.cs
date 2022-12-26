// See https://aka.ms/new-console-template for more information
using Dttl.Qr.Model;
using Dttl.Qr.Util;

VCardQRCode c = new VCardQRCode();
c.FirstName = "Praveen";
c.CompanyName = "Kanini";

Console.WriteLine(VCardUtil.GetVCard(c));