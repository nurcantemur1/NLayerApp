using NLayer.Core.DTOs;

namespace NLayer.WebApp.Services
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ProductWithCategoryDto>> ProductWithCategoryDtos()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ProductWithCategoryDto>>>("product/GetProductWithCategory");
            return response.Data;
        }

        public async Task<ProductDto> Add(ProductDto productDto)
        {
            var response = await _httpClient.PostAsJsonAsync("product", productDto);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var productDtoBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<ProductDto>>();
            return productDtoBody.Data;
        }
        public async Task<bool> Update(ProductDto productDto)
        {
            var response = await _httpClient.PutAsJsonAsync("product/Update", productDto);
            return response.IsSuccessStatusCode;

        }
        public async Task<bool> Remove(int id)
        {
            var response = await _httpClient.DeleteAsync($"product/{id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<ProductDto> GetById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<ProductDto>>($"product/{id}");
            var c = response.Data;
            return response.Data;
        }
        /*   public async Task<List<ProductDto>> GetAll()
           {
               var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ProductDto>>>("product/getall");
               return response.Data;
           }*/
    }
}
