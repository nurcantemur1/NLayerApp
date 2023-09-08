using NLayer.Core.DTOs;
using NLayer.Core.Entity;

namespace NLayer.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<CustomResponseDto<CategoryWithProductsDto>> CategoryWithProducts(int categoryId);
    }
}
