using NasaMarsPhotos.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace NasaMarsPhotos.Web.Services
{
    public class NasaMarsRoverPhotoService : IMarsPhotoService
    {
        public NasaMarsRoverPhotoService(IMarsPhotoService apiDataService=null)
        {
            if (null != apiDataService)
            {
                _apiService = apiDataService;
            }
        }

        private IMarsPhotoService _apiService = null;
        protected IMarsPhotoService apiService
        {
            get
            {
                if (null == _apiService)
                {
                    _apiService = new MarsPhotoService();
                }
                return _apiService;
            }
        }

        public bool CheckEndpointAvailability()
        {
            return apiService.CheckEndpointAvailability();
        }

        public Task<string> GetFirstPhoto(MarsPhotoQueryParameters queryParams)
        {
            return apiService.GetFirstPhoto(queryParams);
        }
    }
}