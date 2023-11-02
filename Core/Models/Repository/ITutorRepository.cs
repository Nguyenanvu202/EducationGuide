using Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Repository
{
	public interface ITutorRepository
	{
		Task<List<Tutors>>GetAllTutorsAsync();

		Task<Tutors>GetTutorsAsync(int id);

		Task<Tutors>CreateTutorsAsync(Tutors tutor);

		Task<Tutors>UpdateAsync(int id, Tutors tutors);

		Task<Tutors>DeleteAsync(int id);
	}
}
