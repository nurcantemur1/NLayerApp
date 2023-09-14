using NLayer.Core.DTOs;

namespace NLayer.WebApp.Services
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CategoryDto>> GetAllCategories()
        {
            var list = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<CategoryDto>>>("category/getall");
            var c = list.Data;
            return list.Data;
        }

    }
}
