using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Domain
{
    public class Page : BaseEntity
    {
        public string Url { get; set; } = string.Empty;
        public virtual ICollection<Section> Sections { get; set; }
    }
}
