using Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Repository
{
	public interface ISectionRepository
	{

		Task<List<Section>> GetSectionsByPageId(int pageId);

		Task<Section> GetSectionAsync(int pageId, int Id);

		Task<Section> CreateSectionAsync( Section section);

		Task<Section> UpdateAsync(Section section,int Id , int pageId, string userRole);

		Task<Section> DeleteAsync(int Id, int pageId);
	}
}
