using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NasaMarsPhotos.Web.Models;
using NasaMarsPhotos.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMarsPhotosWeb.UnitTests.Services.NasaMarsRoverPhotoService_UnitTests
{
    [TestClass]
    public class MarsPhotoService_GetPhotos_UnitTests
    {
        [TestMethod]
        public async Task MarsPhotoService_GetPhotos_Should_Do_QUickUnitTestProofOfConcept()
        {
            var expectedPhotoResults = new List<NasaMarsRoverPhoto>();
            var expectedCollection = new NasaMarsRoverPhotoCollection();
            expectedCollection.Photos = expectedPhotoResults;
            var mockConfigReader = new Mock<IWebConfigAccessor>();
            var mockHttpClient = new Mock<IMiniHttpClient>();
            mockHttpClient.Setup(x => x.MakeRequestGetJsonData<NasaMarsRoverPhotoCollection>(It.IsAny<string>()))
                .ReturnsAsync(expectedCollection);
            var photoService = new MarsPhotoService(mockConfigReader.Object, mockHttpClient.Object);
            
            var queryParams = new MarsPhotoQueryParameters();
            var actualPhotoResults = await photoService.GetPhotos(queryParams);
            Assert.AreEqual(expectedPhotoResults, actualPhotoResults);
        }
    }
}
