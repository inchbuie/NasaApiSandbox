using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NasaMarsPhotos.Web.Services;

namespace NasaMarsPhotosWeb.UnitTests.Services.ConfigurationAccessor_UnitTests
{
    [TestClass]
    public class GetAppSettingValue_UnitTests
    {
        [TestMethod]
        public void WebConfigAccessor_GetAppSettingValue_Should_ReadAppSettingFor_ApiKey()
        {
            const string appSettingName = "ApiKey";
            const string expectedValue = "xyz123";
            var configAccessor = new WebConfigAccessor();
            var valueRead = configAccessor.ReadAppSettingsValue(appSettingName);
            Assert.AreEqual(expectedValue, valueRead);
        }

        [TestMethod]
        public void WebConfigAccessor_GetAppSettingValue_Should_ReadAppSettingFor_NasaUriHost()
        {
            const string appSettingName = "NasaUriHost";
            const string expectedValue = "api.fake.org";
            var configAccessor = new WebConfigAccessor();
            var valueRead = configAccessor.ReadAppSettingsValue(appSettingName);
            Assert.AreEqual(expectedValue, valueRead);
        }

        [TestMethod]
        public void WebConfigAccessor_GetAppSettingValue_Should_ReadAppSettingFor_MarsRoversBasePath()
        {
            const string appSettingName = "MarsRoversBasePath";
            const string expectedValue = "mars-photos/api/v1/rovers";
            var configAccessor = new WebConfigAccessor();
            var valueRead = configAccessor.ReadAppSettingsValue(appSettingName);
            Assert.AreEqual(expectedValue, valueRead);
        }
    }
}
