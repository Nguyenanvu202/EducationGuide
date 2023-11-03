using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Domain
{
    public class Tutors : BaseEntity
    {
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Phone { get; set; }
        public string FacebookUrl { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public int Gender { get; set; }

        public virtual ICollection<CourseTutor> CourseTutors { get; set; }
    }
}
