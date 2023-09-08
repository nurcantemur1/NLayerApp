using NLayer.Core.Entity;

namespace NLayer.Core.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsWithCategoty();
    }
}
