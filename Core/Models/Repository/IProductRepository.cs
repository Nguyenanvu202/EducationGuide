using Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Repository
{
    public interface IProductRepository
    {
        Task<IReadOnlyList<Product>> GetAllProductAsync(string sortBy, int? BrandId, int? TypesId
            , int pageNumber, int pageSize, string filterName);
        Task<IReadOnlyList<ProductBrand>> GetAllProductBrandAsync();
        Task<IReadOnlyList<ProductType>> GetAllProductTypeAsync();
        Task<Product> GetByIdAsync(int id);

    }
}
