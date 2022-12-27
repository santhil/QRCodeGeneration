using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dttl.Qr.Model
{
    public class FilterData
    {
        public string? TemplateName { get; set; }
        public string? ForeColor { get; set; }
        public string? BackgroundColor { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
    }
}
