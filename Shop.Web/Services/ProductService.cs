using Shop.Share;
using Shop.Web.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace E2E.Web.Services
{
    
    public class ProductService: BaseService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient):base(httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<ProductModel>> GetProductsAsync(int page,int size,string keyword)
        {
            try
            {
                string url = $"api/Product?page={page}&size={size}&keyword{keyword}";
                var data = await _httpClient.GetStreamAsync(url);
                return await JsonSerializer.DeserializeAsync<IEnumerable<ProductModel>>
                    (data, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
