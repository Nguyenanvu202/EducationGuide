using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Domain
{
	public class CourseTutor : BaseEntity
	{
		public int TutorId { get; set; }
		public virtual Tutors Tutors { get; set; }

		public int CourseId { get; set; }
		public virtual Course Course { get; set; }
	}
}
