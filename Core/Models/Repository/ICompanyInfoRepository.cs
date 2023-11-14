using Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Repository
{
	public interface ICompanyInfoRepository
	{
		public Task<List<CompanyInfo>> GetAllAsync();
		public Task<CompanyInfo> GetCompanyAsync(int Id);
		public Task<CompanyInfo> UpdateCompanyAsync(int Id, CompanyInfo companyInfo);
		public Task<CompanyInfo> CreateCompanyAsync(CompanyInfo companyInfo);
		public Task<CompanyInfo> DeleteCompanyInfoAsync(int Id);

	}
}
