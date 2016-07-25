using Microsoft.VisualStudio.TestTools.UnitTesting;
using NasaMarsPhotos.Web.Services;
using NasaMarsPhotos.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMarsPhotosWeb.UnitTests.Services.MarsPhotoQueryViewModelConverter_UnitTests
{
    [TestClass]
    public class FromViewModelUnitTests
    {
        [TestMethod]
        public void MarsPhotoQueryViewModelConverter_FromViewModel_Should_ConvertRoverProperty()
        {
            //Arrange
            const string expectedRover = "Curiosity";
            var viewModel = new MarsRoverPhotosQueryViewModel()
            {
                Rover = expectedRover
            };
            //Act
            var converted = MarsPhotoQueryViewModelConverter.FromViewModel(viewModel);
            //Assert
            Assert.AreEqual(expectedRover, converted.Rover.ToString());
        }

        [TestMethod]
        public void MarsPhotoQueryViewModelConverter_FromViewModel_Should_ConvertCameraProperty()
        {
            //Arrange
            const string expectedCamera = "MAST";
            var viewModel = new MarsRoverPhotosQueryViewModel()
            {
                Camera = expectedCamera
            };
            //Act
            var converted = MarsPhotoQueryViewModelConverter.FromViewModel(viewModel);
            //Assert
            Assert.AreEqual(expectedCamera, converted.Camera.ToString());
        }

        [TestMethod]
        public void MarsPhotoQueryViewModelConverter_FromViewModel_Should_ConvertSolProperty()
        {
            //Arrange
            const int expectedSol = 101;
            var viewModel = new MarsRoverPhotosQueryViewModel()
            {
                MissionSol = expectedSol
            };
            //Act
            var converted = MarsPhotoQueryViewModelConverter.FromViewModel(viewModel);
            //Assert
            Assert.AreEqual(expectedSol, converted.MissionSol);
        }

    }
}
