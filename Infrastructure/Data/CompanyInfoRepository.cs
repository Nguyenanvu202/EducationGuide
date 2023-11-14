using Core.Models.Domain;
using Core.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Infrastructure.Data
{
    public class CompanyInfoRepository : ICompanyInfoRepository
    {
        private readonly PageContext _pageContext;

        public CompanyInfoRepository(PageContext pageContext)
        {
            _pageContext = pageContext;
        }
        
        
        public async Task<CompanyInfo> CreateCompanyAsync(CompanyInfo companyInfo)
        {
            await _pageContext.AddAsync(companyInfo);
             await _pageContext.SaveChangesAsync();
            return companyInfo;
        }

        public async Task<CompanyInfo> DeleteCompanyInfoAsync(int Id)
        {
            var companyInfo = await _pageContext.CompanyInfos.FirstOrDefaultAsync(i=>i.Id == Id);
             _pageContext.Remove(companyInfo);
            await _pageContext.SaveChangesAsync();
            return companyInfo;
        }

        public async Task<List<CompanyInfo>> GetAllAsync()
        {
            {
                try
                {
                    var companyInfo = await _pageContext.CompanyInfos.ToListAsync();
                    return companyInfo;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }


        public async Task<CompanyInfo> GetCompanyAsync(int Id)
        {
            var companyInfo = await _pageContext.CompanyInfos.FirstOrDefaultAsync(x => x.Id == Id);

            if (companyInfo == null)
            {
                return null;
            }

            return companyInfo;
        }

        public async Task<CompanyInfo> UpdateCompanyAsync(int Id, CompanyInfo companyInfo)
        {
            var companyInfoExist = await _pageContext.CompanyInfos.FirstOrDefaultAsync(x =>x.Id == Id);
            if (companyInfo == null)
            {
                return null;
            }
            companyInfoExist.UpdatedDate = companyInfo.UpdatedDate;
            companyInfoExist.CreatedDate = companyInfo.CreatedDate;
            companyInfoExist.UpdatedBy = companyInfo.UpdatedBy;
            companyInfoExist.CreatedBy = companyInfo.CreatedBy;

            companyInfo.Name = companyInfo.Name;
            companyInfo.Adress = companyInfo.Adress;
            companyInfo.Email = companyInfo.Email;
            companyInfo.Phone = companyInfo.Phone;

            return companyInfo;

        }
    }
}
