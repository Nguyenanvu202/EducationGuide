using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Domain
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public string CreatedBy { get; set; } = string.Empty;
		public DateTime UpdatedDate { get; set; } = DateTime.Now;
		public string UpdatedBy { get; set; } = string.Empty;
	}
}
