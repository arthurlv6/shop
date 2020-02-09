using Shop.Share;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shop.Web.Services
{
    
    public class BaseService
    {
        private readonly HttpClient httpClient;
        public BaseService(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }
        public async Task<IEnumerable<M>> GetAll<M>(M m) where M:BaseModel
        {
            try
            {
                string url = "api/"+m.GetType().Name.Remove(m.GetType().Name.IndexOf("Model"), "Model".Length);
                var data = await httpClient.GetStreamAsync(url);
                return await JsonSerializer.DeserializeAsync<IEnumerable<M>>
                    (data, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
