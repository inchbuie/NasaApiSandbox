using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NasaMarsPhotos.DataService;

namespace NasaMarsPhotosDataService.UnitTests.ApiUriBuilder_UnitTests
{
    [TestClass]
    public class GetBaseUri_UnitTests
    {
        [TestMethod]
        public void ApiUriBuilder_GetHostUri_Should_GetExpectedValuesFromConfig()
        {
            const string expectedUri = "https://api.fake.org/mars-photos/api/v1/rovers";
            var uriBuilder = new ApiUriBuilder();
            var assembledUri = uriBuilder.GetBaseUri();
            Assert.AreEqual(expectedUri, assembledUri);
        }
    }
}
