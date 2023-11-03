using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Domain
{
	public class Course : BaseEntity
	{
        public string Subject { get; set; }

		public virtual ICollection<CourseTutor> CourseTutors { get; set; }
    }
}
