using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NasaMarsPhotos.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMarsPhotosWeb.UnitTests.Services.NasaMarsRoverPhotoService_UnitTests
{
    [TestClass]
    public class MarsPhotoService_CheckEndpointAvailability_UnitTests
    {
        protected Mock<IMarsPhotoService> mockNasaService = new Mock<IMarsPhotoService>();

        [TestMethod]
        public void MarsPhotoService_CheckEndpointAvailability_Should_ReportStatus_WhenAvailable()
        {
            bool isAvailable = true;
            mockNasaService.Setup(s => s.CheckEndpointAvailability()).Returns(isAvailable);
            var result = mockNasaService.Object.CheckEndpointAvailability();
            Assert.AreEqual(isAvailable, result);
        }

        [TestMethod]
        public void MarsPhotoService_CheckEndpointAvailability_Should_ReportStatus_WhenNotAvailable()
        {
            bool notAvailable = false;
            mockNasaService.Setup(s => s.CheckEndpointAvailability()).Returns(notAvailable);
            var result = mockNasaService.Object.CheckEndpointAvailability();
            Assert.AreEqual(notAvailable, result);
        }
    }
}
