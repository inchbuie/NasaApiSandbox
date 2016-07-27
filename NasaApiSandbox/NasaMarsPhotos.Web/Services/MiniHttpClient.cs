using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace NasaMarsPhotos.Web.Services
{
    public class MiniHttpClient : IMiniHttpClient
    {
        public MiniHttpClient(string baseAddress)
        {
            BaseAddress = baseAddress;
        }

        public string BaseAddress { get; set; }

        public async Task<T> MakeRequestGetJsonData<T>(string queryArgs)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(BaseAddress);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync(queryArgs);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<T>(jsonString);
                    return data;
                }
            }
            return default(T);
        }
    }
}