using NasaMarsPhotos.DataService;
using NasaMarsPhotos.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasaMarsPhotos.Web.Services
{
    public static class MarsPhotoQueryViewModelConverter
    {
        public static MarsPhotoQueryParameters FromViewModel(MarsRoverPhotosQueryViewModel viewModel)
        {
            var queryObj = new MarsPhotoQueryParameters();
            MarsRoverEnum rover = MarsRoverEnum.Unspecified;
            if (Enum.TryParse<MarsRoverEnum>(viewModel.Rover, out rover))
            {
                queryObj.Rover = rover;
            }
            MarsRoverCameraEnum camera = MarsRoverCameraEnum.Unspecified;
            if (Enum.TryParse<MarsRoverCameraEnum>(viewModel.Camera, out camera))
            {
                queryObj.Camera = camera;
            }
            queryObj.MissionSol = viewModel.MissionSol;
            queryObj.EarthDate = viewModel.EarthDate;
            queryObj.Page = viewModel.Page;

            return queryObj;
        }
    }
}