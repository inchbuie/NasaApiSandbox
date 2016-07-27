using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NasaMarsPhotos.DataService
{
    /// <summary>
    /// Main entry points for the data service
    /// </summary>
    public class MarsPhotoService : IMarsPhotoService
    {
        ApiUriBuilder uriBuilder = new ApiUriBuilder();

        /// <summary>
        /// Attempts to ping (verify the ability to make a connection with)
        ///  the target endpoint
        /// </summary>
        /// <returns></returns>
        public bool CheckEndpointAvailability()
        {
            return false;
        }

        /// <summary>
        /// Retrieves a photo from the API service.
        /// Only the first photo of any which match the query parameters
        ///   will be returned.
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public async Task<string> GetFirstPhoto(MarsPhotoQueryParameters queryParams)
        {
            var apiBaseAddress = uriBuilder.GetBaseUri();
            var queryArgs = queryParams.ToString();
            string result = null;

            using (var httpClient = new HttpClient())
            {
                // New code:
                httpClient.BaseAddress = new Uri(apiBaseAddress);
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync(queryArgs);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync(); 
                }            
            }
            return result;
        }
    }
}
