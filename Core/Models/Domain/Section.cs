using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Domain
{
    public class Section : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string? ImageUrl { get; set; }
        public string? BackgroundUrl { get; set; }

        public int PageId { get; set; }
        public virtual Page Page { get; set; }
    }
}
