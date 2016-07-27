using Microsoft.VisualStudio.TestTools.UnitTesting;
using NasaMarsPhotos.Web.Models;
using NasaMarsPhotos.Web.Services;
using NasaMarsPhotos.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMarsPhotosWeb.UnitTests.Services.NasaMarsRoverPhotoService_UnitTests
{
    [TestClass]
    public class MarsPhotoService_FromViewModelUnitTests
    {
        [TestMethod]
        public void MarsPhotoService_FromViewModel_Should_ConvertRoverProperty()
        {
            //Arrange
            const string expectedRover = "Curiosity";
            var viewModel = new MarsRoverPhotosQueryViewModel()
            {
                SelectedRoverId = (int)MarsRoverEnum.Curiosity
            };
            //Act
            var converted = MarsPhotoService.FromViewModel(viewModel);
            //Assert
            Assert.AreEqual(expectedRover, converted.Rover.ToString());
        }

        [TestMethod]
        public void MarsPhotoService_FromViewModel_Should_ConvertCameraProperty()
        {
            //Arrange
            const string expectedCamera = "MAST";
            var viewModel = new MarsRoverPhotosQueryViewModel()
            {
                SelectedCameraId = (int)MarsRoverCameraEnum.MAST
            };
            //Act
            var converted = MarsPhotoService.FromViewModel(viewModel);
            //Assert
            Assert.AreEqual(expectedCamera, converted.Camera.ToString());
        }

        [TestMethod]
        public void MarsPhotoService_FromViewModel_Should_ConvertSolProperty()
        {
            //Arrange
            const int expectedSol = 101;
            var viewModel = new MarsRoverPhotosQueryViewModel()
            {
                MissionSol = expectedSol
            };
            //Act
            var converted = MarsPhotoService.FromViewModel(viewModel);
            //Assert
            Assert.AreEqual(expectedSol, converted.MissionSol);
        }

    }
}
