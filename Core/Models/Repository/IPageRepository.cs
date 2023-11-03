using Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Repository
{
	public interface IPageRepository
	{
		Task<Page> GetByUrlAsync(string url);
		
		Task<List<Page>>GetAllPagesAsync();

		Task<Page> GetPagesAsync(int id);

		Task<Page> CreatePagesAsync(Page pages);

		Task<Page> UpdateAsync(int id, Page pages);

		Task<Page> DeleteAsync(int id);
	}
}
