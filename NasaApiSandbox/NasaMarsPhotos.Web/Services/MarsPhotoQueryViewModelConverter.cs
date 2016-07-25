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
            //queryObj.Rover = viewModel.Rover;
            //queryObj.Camera = viewModel.Camera;
            queryObj.MissionSol = viewModel.MissionSol;
            queryObj.EarthDate = viewModel.EarthDate;
            queryObj.Page = viewModel.Page;

            return queryObj;
        }
    }
}