using Core.Models.Domain;
using Core.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
	public class TutorRepository : ITutorRepository
	{
		private readonly PageContext pageContext;

		public TutorRepository(PageContext pageContext)
        {
			this.pageContext = pageContext;
		}


        public async Task<Tutors> CreateTutorsAsync(Tutors tutor)
		{
			await pageContext.Tutors.AddAsync(tutor);

			pageContext.SaveChanges();

			return tutor;
			
		}

		public async Task<Tutors> DeleteAsync(int id)
		{
			var tutorExist = await pageContext.Tutors.FirstOrDefaultAsync(t => t.Id == id);
			if (tutorExist == null)
			{
				return null;
			}
			pageContext.Tutors.Remove(tutorExist);
			await pageContext.SaveChangesAsync();
			return tutorExist;
		}

		public async Task<List<Tutors>> GetAllTutorsAsync()
		{
			try
			{
				var tutor = await pageContext.Tutors.Include("CourseTutors").ToListAsync();
				return tutor;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			
		}

		public async Task<Tutors> GetTutorsAsync(int id)
		{
			var tutor = await pageContext.Tutors.Include(t => t.CourseTutors).ThenInclude(ct => ct.Course).FirstOrDefaultAsync(x => x.Id == id);
			if(tutor == null)
			{
				return null;
			}
			return tutor;
		}

		public async Task<Tutors> UpdateAsync(int id, Tutors tutors)
		{
			var existTutor = await pageContext.Tutors.FirstOrDefaultAsync(x => x.Id == id);
			if(existTutor == null)
			{
				return null;
			}

			existTutor.Name = tutors.Name;
			existTutor.FacebookUrl = tutors.FacebookUrl;
			existTutor.ImgUrl = tutors.ImgUrl;
			existTutor.Description = tutors.Description;
			existTutor.Email = tutors.Email;
			existTutor.Phone = tutors.Phone;

			return existTutor;
		}
	}
}
