using NasaMarsPhotos.Web.Services;
using NasaMarsPhotos.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NasaMarsPhotos.Web.Controllers
{
    public class PhotosController : Controller
    {
        protected IMarsPhotoService nasaService = null;

        public PhotosController()
        {
            if (null == nasaService)
            {
                nasaService = new MarsPhotoService();
            }
        }
        public PhotosController(IMarsPhotoService marsPhotoService) : this()
        {
            nasaService = marsPhotoService;
        }
        
        public async Task<ActionResult> Index(MarsRoverPhotosQueryViewModel queryParams)
        {
            var queryObj = nasaService.FromViewModel(queryParams);
            var apiData = await nasaService.GetPhotos(queryObj);
            return View(apiData);
        }
    }
}