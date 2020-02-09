using Shop.Share;
using Shop.Web.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E2E.Web.Services
{
    
    public class ProductLinkService : BaseService
    {
        private readonly HttpClient _httpClient;
        public ProductLinkService(HttpClient httpClient):base(httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ProductLinkModel> PostProductLinkAsync(ProductLinkModel productLinkModel)
        {
            try
            {
                var linkJson = new StringContent(JsonSerializer.Serialize(productLinkModel), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/ProductLink", linkJson);

                if (response.IsSuccessStatusCode)
                {
                    return await JsonSerializer.DeserializeAsync<ProductLinkModel>(await response.Content.ReadAsStreamAsync());
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
