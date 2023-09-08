using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entity;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWithCategoty()
        {
            //Eager loading
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }

    }
}
