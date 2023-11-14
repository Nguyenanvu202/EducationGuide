using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Dtos
{
	public class TutorCreate
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ImgUrl { get; set; }
		public string Phone { get; set; }
		public string FacebookUrl { get; set; }
		public string Email { get; set; }
		public string Description { get; set; }
	}
}
