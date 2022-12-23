using Microsoft.EntityFrameworkCore;
using QRCodeGeneration.Model;
using System.Collections.Generic;

namespace QRCodeGeneration.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("CS"));
        }
        public DbSet<QRDetails> qRDetails { get; set; }
        public DbSet<QrCode> qrCode { get; set; }
        public DbSet<QRTemplate> _qRTemplates { get; set; }
        public DbSet<VCardDetails> vCardDetails { get; set; }
    }
}
