using Azure;
using Core.Models.Domain;
using Core.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Infrastructure.Data
{
	public class SectionRepository : ISectionRepository
	{
		private readonly PageContext _pageContext;

		public SectionRepository(PageContext _pageContext)
        {
			this._pageContext = _pageContext;
		}

		public async Task<Section> CreateSectionAsync(Section section)
		{
			await _pageContext.Sections.AddAsync(section);
			await _pageContext.SaveChangesAsync();
			return section;
		}

		public async Task<Section> DeleteAsync(int Id, int pageId)
		{
			var existSection = await _pageContext.Sections
				.Where(s => s.PageId == pageId).FirstOrDefaultAsync(i => i.Id == Id);
			if (existSection == null)
			{
				return null;
			}
			_pageContext.Sections.Remove(existSection);
			await _pageContext.SaveChangesAsync();
			return existSection;
		}

		public async Task<Section> GetSectionAsync(int pageId, int Id)
		{
			return await _pageContext.Sections
				.Where(s => s.PageId == pageId).FirstOrDefaultAsync(i => i.Id == Id);
		}

		public async Task<List<Section>> GetSectionsByPageId(int pageId)
		{
			return await _pageContext.Sections.Where(s => s.PageId == pageId).ToListAsync();

		}

        public async Task<Section> UpdateAsync(Section section, int Id, int pageId, string userRole)
        {
            // Find the existing section based on Id and pageId
            var existSection = await _pageContext.Sections
                .Where(s => s.PageId == pageId && s.Id == Id)
                .FirstOrDefaultAsync();

            if (existSection == null)
            {
                return null;
            }

            section.UpdatedDate = DateTime.UtcNow; 
            section.UpdatedBy = userRole; 

            section.Title = existSection.Title;
            section.Content = existSection.Content;
            section.ImageUrl = existSection.ImageUrl;
            section.BackgroundUrl = existSection.BackgroundUrl;

            await _pageContext.SaveChangesAsync();

            return section;
        }

    }
}
