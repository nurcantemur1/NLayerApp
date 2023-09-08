using NLayer.Core.DTOs;
using NLayer.Core.Entity;

namespace NLayer.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategoty();
    }
}
