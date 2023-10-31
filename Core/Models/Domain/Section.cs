using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Domain
{
    public class Section : Page
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string? ImageUrl { get; set; }
        public string? BackgroundUrl { get; set; }

        public CompanyInfo? CompanyInfo { get; set; }
        public ContactForm? ContactForm { get; set; }
    }
}
