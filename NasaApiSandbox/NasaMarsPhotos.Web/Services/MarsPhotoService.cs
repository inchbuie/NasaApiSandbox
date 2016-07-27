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
        protected IMiniHttpClient httpClient = null;

        public MarsPhotoService()
        {
            if (null == configAccessor)
            {
                configAccessor = new WebConfigAccessor();
            }
            if (null == httpClient)
            {
                var apiBaseAddress = GetBaseUri();
                httpClient = new MiniHttpClient(apiBaseAddress);
            }
        }
        public MarsPhotoService(IWebConfigAccessor config, IMiniHttpClient miniHttpClient)
            : this()
        {
            configAccessor = config;
            httpClient = miniHttpClient;
        }
                
        public async Task<IEnumerable<NasaMarsRoverPhoto>> GetPhotos(MarsPhotoQueryParameters queryParams)
        {
            var queryArgs = queryParams.ToString();
            var data = await httpClient.MakeRequestGetJsonData<NasaMarsRoverPhotoCollection>(queryArgs);
            if (null != data)
            {
                return data.Photos;
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

        public IEnumerable<MarsRoverCameraViewModel> GetValidCameraForRover(int roverId)
        {
            var rover = (MarsRoverEnum)roverId;
            var allCameraChoices = Enum.GetValues(typeof(MarsRoverCameraEnum)).Cast<MarsRoverCameraEnum>();
            var validCameraChoices = new List<MarsRoverCameraViewModel>();

            switch (rover)
            {
                case MarsRoverEnum.Curiosity:
                    foreach (var cam in allCameraChoices)
                    {
                        //this rover doesn't have these cameras
                        if (cam != MarsRoverCameraEnum.PANCAM &&
                            cam != MarsRoverCameraEnum.MINITES)
                        {
                            validCameraChoices.Add(new MarsRoverCameraViewModel((int)cam, cam.ToString()));
                        }
                    }
                    break;
                case MarsRoverEnum.Opportunity:
                case MarsRoverEnum.Spirit:
                    foreach (var cam in allCameraChoices)
                    {
                        //these rovers don't have these cameras
                        if (cam != MarsRoverCameraEnum.MAST &&
                            cam != MarsRoverCameraEnum.CHEMCAM &&
                            cam != MarsRoverCameraEnum.MAHLI &&
                            cam != MarsRoverCameraEnum.MARDI)
                        {
                            validCameraChoices.Add(new MarsRoverCameraViewModel((int)cam, cam.ToString()));
                        }
                    }
                    break;
                case MarsRoverEnum.Unspecified:
                default:
                    foreach (var cam in allCameraChoices)
                    {
                        validCameraChoices.Add(new MarsRoverCameraViewModel((int)cam, cam.ToString()));
                    }
                    break;
            }
            return validCameraChoices;
        }
    }
}
