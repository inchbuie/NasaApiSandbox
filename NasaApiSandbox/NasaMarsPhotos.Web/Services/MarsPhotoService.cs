using NasaMarsPhotos.Web.Models;
using NasaMarsPhotos.Web.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NasaMarsPhotos.Web.Services
{
    /// <summary>
    /// Main entry points for the data service
    /// </summary>
    public class MarsPhotoService : IMarsPhotoService
    {
        protected const string appSettingName_ApiHost = "NasaUriHost";
        protected const string defaultApiHost = "";
        protected const string appSettingName_ApiBasePath = "MarsRoversBasePath";
        protected const string defaultRootPath = "";
        protected const string secure_scheme = "https";
        protected const string appSettingName_ApiKey = "ApiKey";
        protected const string defaultApiKey = "DEMO_KEY";

        protected IWebConfigAccessor configAccessor = null;
        
        public MarsPhotoService()
        {
            if (null == configAccessor)
            {
                configAccessor = new WebConfigAccessor();
            }
        }
        public MarsPhotoService(IWebConfigAccessor config) : this()
        {
            configAccessor = config;
        }

        /// <summary>
        /// Attempts to ping (verify the ability to make a connection with)
        ///  the target endpoint
        /// </summary>
        /// <returns></returns>
        public bool CheckEndpointAvailability()
        {
            return false;
        }
        
        public async Task<IEnumerable<NasaMarsRoverPhoto>> GetPhotos(MarsPhotoQueryParameters queryParams)
        {
            var apiBaseAddress = GetBaseUri();
            var queryArgs = queryParams.ToString();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(apiBaseAddress);
                //client.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync(queryArgs);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<NasaMarsRoverPhotoCollection>(jsonString);
                    return data.Photos;
                }
            }
            return null;
        }

        public MarsPhotoQueryParameters FromViewModel(MarsRoverPhotosQueryViewModel viewModel)
        {
            var queryObj = new MarsPhotoQueryParameters();
            if (Enum.IsDefined(typeof(MarsRoverEnum), viewModel.SelectedRoverId))
            {
                queryObj.Rover = (MarsRoverEnum)viewModel.SelectedRoverId;
            }
            if (Enum.IsDefined(typeof(MarsRoverCameraEnum), viewModel.SelectedCameraId))
            {
                queryObj.Camera = (MarsRoverCameraEnum)viewModel.SelectedCameraId;
            }
            queryObj.MissionSol = viewModel.MissionSol;
            queryObj.EarthDate = viewModel.EarthDate;
            queryObj.Page = viewModel.Page;

            var apiKey = configAccessor.ReadAppSettingsValue(appSettingName_ApiKey);
            queryObj.ApiKey = apiKey;
            var rootPath = configAccessor.ReadAppSettingsValue(appSettingName_ApiBasePath);
            queryObj.RootPath = rootPath;
            return queryObj;
        }

        public MarsRoverPhotosQueryViewModel ToViewModel(MarsPhotoQueryParameters queryObj)
        {
            var viewModel = new MarsRoverPhotosQueryViewModel();
            viewModel.SelectedRoverId = (int)queryObj.Rover;
            viewModel.SelectedCameraId = (int)queryObj.Camera;
            if (queryObj.MissionSol.HasValue)
            {
                viewModel.MissionSol = queryObj.MissionSol;
            }
            if (queryObj.EarthDate.HasValue)
            {
                viewModel.EarthDate = queryObj.EarthDate;
            }
            viewModel.Page = queryObj.Page;
            return viewModel;
        }

        public string GetHostUri()
        {
            var host = configAccessor.ReadAppSettingsValue(appSettingName_ApiHost, defaultApiHost);
            UriBuilder builder = new UriBuilder(secure_scheme, host);
            return builder.ToString();
        }

        public string GetBaseUri()
        {
            var host = configAccessor.ReadAppSettingsValue(appSettingName_ApiHost, defaultApiHost);
            UriBuilder builder = new UriBuilder(secure_scheme, host);
            var rootPath = configAccessor.ReadAppSettingsValue(appSettingName_ApiBasePath, defaultRootPath);
            builder.Path = rootPath;
            return builder.ToString();
        }
    }
}
