using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NasaMarsPhotos.Web.Services;

namespace NasaMarsPhotosWeb.UnitTests.Services.ApiUriBuilder_UnitTests
{
    [TestClass]
    public class MarsPhotoService_GetNasaMarsRoverPhotosUri_UnitTests
    {
        [TestMethod]
        public void MarsPhotoService_GetHostUri_Should_GetExpectedValuesFromConfig()
        {
            const string expectedUri = "https://api.fake.org/";
            var photoService = new MarsPhotoService(new WebConfigAccessor());
            var assembledUri = photoService.GetHostUri();
            Assert.AreEqual(expectedUri, assembledUri);
        }
    }
}
