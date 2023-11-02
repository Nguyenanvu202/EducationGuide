using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Domain
{
    public class Tutors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Phone { get; set; }
        public string FacebookUrl { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public int GenderId { get; set; }
        public int CourseId { get; set; }

        public Gender Gender { get; set; }
        public Course Course { get; set; }
    }
}
