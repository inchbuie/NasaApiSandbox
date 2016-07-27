using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NasaMarsPhotos.Web.Services;
using Moq;

namespace NasaMarsPhotosWeb.UnitTests.Services.ApiUriBuilder_UnitTests
{
    [TestClass]
    public class MarsPhotoService_GetNasaMarsRoverPhotosUri_UnitTests
    {
        [TestMethod]
        public void MarsPhotoService_GetHostUri_Should_GetExpectedValuesFromConfig()
        {
            const string expectedUri = "https://api.fake.org/";
            var configReader = new WebConfigAccessor();
            var httpClient = new Mock<IMiniHttpClient>().Object;
            var photoService = new MarsPhotoService(configReader, httpClient);
            var assembledUri = photoService.GetHostUri();
            Assert.AreEqual(expectedUri, assembledUri);
        }
    }
}
