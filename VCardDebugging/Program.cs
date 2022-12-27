// See https://aka.ms/new-console-template for more information
using Dttl.Qr.Model;
using Dttl.Qr.Util;
using System.Net.Security;

string fileName = @"C:\Users\Lenovo India\Desktop\Test.jpg";

VCardQRCode c = new VCardQRCode();
c.FirstName = "Praveen";
c.LastName = "Ranjan";
c.CompanyName = "Kanini";
c.Designation = "Software Developer";
c.MobileNo = "9000000000";
c.EmailId = "Test@kanini.com";
c.Website = "kanini.com";
c.PersonalLinks = "www.google.com";
c.UploadImage = await System.IO.File.ReadAllBytesAsync(fileName);
Console.WriteLine(VCardUtil.GetVCard(c));
