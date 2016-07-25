using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMarsPhotos.DataService
{
    /// <summary>
    /// Class for conveniently getting the uri of the API being accessed by the service
    /// </summary>
    public class ApiUriBuilder
    {
        protected ConfigurationAccessor config = new ConfigurationAccessor();
        protected const string secure_scheme = "https";

        public string GetHostUri()
        {
            var host = config.ApiHost;
            UriBuilder builder = new UriBuilder(secure_scheme, host);
            return builder.ToString();
        }
        public string GetBaseUri()
        {
            var host = config.ApiHost;
            UriBuilder builder = new UriBuilder(secure_scheme, host);
            var rootPath = config.ApiBasePath;
            builder.Path = rootPath;
            return builder.ToString();
        }
    }
}
