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
	public class PageRepository : IPageRepository
	{
		private readonly PageContext pageContext;

		public PageRepository(PageContext pageContext)
        {
			this.pageContext = pageContext;
		}


        public async Task<Page> CreatePagesAsync(Page pages)
		{
			await pageContext.Pages.AddAsync(pages);

			pageContext.SaveChanges();

			return pages;
			
		}


		public async Task<Page> DeleteAsync(int id)
		{
			var pageExist = await pageContext.Pages.FirstOrDefaultAsync(t => t.Id == id);
			if (pageExist == null)
			{
				return null;
			}
			pageContext.Pages.Remove(pageExist);
			await pageContext.SaveChangesAsync();
			return pageExist;
		}

        public async Task<List<string>> GetAllNamePageAsync()
        {
            return await pageContext.Pages.Select(n => n.NamePage).Distinct().ToListAsync();
        }

        public async Task<List<Page>> GetAllPagesAsync()
		{
			try
			{
				var pages = await pageContext.Pages.Include("Section").ToListAsync();
				return pages;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			
		}



        public async Task<List<string>> GetAllUrlAsync()
        {
            
            return await pageContext.Pages.Select(p => p.Url).Distinct().ToListAsync();
        }

        public Page GetPageByUrl(string url)
        {
            return pageContext.Pages.Include("Sections").FirstOrDefault(p => p.Url == url);

        }        
		
		public Page GetPageByName(string name)
        {
            return pageContext.Pages.Include("Sections").FirstOrDefault(p => p.NamePage == name);

        }

        public async Task<Page> GetByUrlAsync(string url)
		{
			return await pageContext.Pages.Include("Sections").FirstOrDefaultAsync(p => p.Url == url);
		}



        public async Task<Page> GetPagesAsync(int id)
		{
			var page = await pageContext.Pages.Include("Sections").FirstOrDefaultAsync(x => x.Id == id);
			if(page == null)
			{
				return null;
			}
			return page;
		}

		public async Task<Page> UpdateAsync(int id, Page pages)
		{
			var existPage = await pageContext.Pages.FirstOrDefaultAsync(x => x.Id == id);
			if(existPage == null)
			{
				return null;
			}

			existPage.UpdatedDate = pages.UpdatedDate;
			existPage.UpdatedBy = pages.UpdatedBy;
			existPage.Url = pages.Url;
			return existPage;
		}
	}
}
