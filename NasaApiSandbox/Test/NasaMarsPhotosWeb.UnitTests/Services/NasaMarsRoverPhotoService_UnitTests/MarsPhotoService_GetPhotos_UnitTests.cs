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
        public void MarsPhotoService_GetPhotos_Should_Do_x()
        {
            var nasaService = new MarsPhotoService();
            var queryParams = new MarsPhotoQueryParameters();
            var result = nasaService.GetPhotos(queryParams);
            throw new NotImplementedException();
            Assert.AreEqual(isAvailable, result);
        }
    }
}
