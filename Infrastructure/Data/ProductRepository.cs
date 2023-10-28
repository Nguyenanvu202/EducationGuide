using Core.Models.Domain;
using Core.Models.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext storeContext;

        public ProductRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public async Task<IReadOnlyList<Product>> GetAllProductAsync(string sortBy
            , int? BrandId, int? TypesId, int pageNumber, int pageSize,string filterName)
        {

            var product = storeContext.Products
                .Include("ProductBrand")
                .Include("ProductType")
                .AsQueryable();
            //sorting
            if(string.IsNullOrEmpty(sortBy) == false )
            {
                
                if(sortBy.Equals("PriceDesc", StringComparison.OrdinalIgnoreCase))
                {
                    product = product.OrderByDescending(x => x.Price);
                }

                if (sortBy.Equals("PriceAsc", StringComparison.OrdinalIgnoreCase))
                {
                    product = product.OrderBy(x => x.Price);
                }
            }

            //filter
           if(BrandId != null)
            {
                product = product.Where(x => x.ProductBrandId == BrandId);
            }
            
            if(TypesId != null)
            {
                product = product.Where(x => x.ProductTypeId == TypesId);
            }
            //Searching
            if(filterName.IsNullOrEmpty() == false)
            {
                product = product.Where(x => x.Name.Contains(filterName));
            }

            //pagination
            var skipResults = (pageNumber - 1) * pageSize;

            return await product.Skip(skipResults).Take(pageSize).ToListAsync();
            
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            return await storeContext.Products
                .Include("ProductBrand")
                .Include("ProductType")
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IReadOnlyList<ProductBrand>> GetAllProductBrandAsync()
        {
            return await storeContext.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetAllProductTypeAsync()
        {
            return await storeContext.ProductTypes.ToListAsync();
        }


    }
}
