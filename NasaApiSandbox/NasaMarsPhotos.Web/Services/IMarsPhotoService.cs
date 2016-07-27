using NasaMarsPhotos.Web.Models;
using NasaMarsPhotos.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NasaMarsPhotos.Web.Services
{
    public interface IMarsPhotoService
    {
        Task<IEnumerable<NasaMarsRoverPhoto>> GetPhotos(MarsPhotoQueryParameters queryParams);
        MarsPhotoQueryParameters FromViewModel(MarsRoverPhotosQueryViewModel viewModel);
        MarsRoverPhotosQueryViewModel ToViewModel(MarsPhotoQueryParameters queryObj);
        IEnumerable<MarsRoverCameraViewModel> GetValidCameraForRover(int roverId);
    }
}