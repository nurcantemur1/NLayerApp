using NLayer.Core.Entity;

namespace NLayer.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> categoryWithProductsAsync(int categoryId);
    }
}
