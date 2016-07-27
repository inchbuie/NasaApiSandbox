using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NasaMarsPhotos.Web.Services;

namespace NasaMarsPhotosWeb.UnitTests.Services.ApiUriBuilder_UnitTests
{
    [TestClass]
    public class MarsPhotoService_GetBaseUri_UnitTests
    {
        [TestMethod]
        public void MarsPhotoService_GetHostUri_Should_GetExpectedValuesFromConfig()
        {
            const string expectedUri = "https://api.fake.org/mars-photos/api/v1/rovers";
            var photoService = new MarsPhotoService(new WebConfigAccessor());
            var assembledUri = photoService.GetBaseUri();
            Assert.AreEqual(expectedUri, assembledUri);
        }
    }
}
