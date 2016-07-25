using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMarsPhotos.DataService
{
    /// <summary>
    /// Class for reading values from the app.config
    /// </summary>
    public class ConfigurationAccessor
    {
        const string appSettingName_ApiHost = "NasaUriHost";
        const string defaultApiHost = "";

        const string appSettingName_ApiBasePath = "MarsRoversBasePath";
        const string defaultRootPath = "";

        const string appSettingName_ApiKey = "ApiKey";

        public string GetAppSettingValue(string appSettingName)
        {
            var settingValue = ConfigurationManager.AppSettings.Get(appSettingName);
            return settingValue;
        }

        public string ApiHost
        {
            get
            {
                return GetAppSettingValue(appSettingName_ApiHost) ?? defaultApiHost;
            }
        }

        public string ApiBasePath
        {
            get
            {
                return GetAppSettingValue(appSettingName_ApiBasePath) ?? defaultRootPath;
            }
        }

        public string ApiKey
        {
            get
            {
                return GetAppSettingValue(ApiKey);
            }
        }
    }
}
