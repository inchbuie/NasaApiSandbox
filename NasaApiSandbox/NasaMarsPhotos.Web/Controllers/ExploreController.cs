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
    public class ExploreController : Controller
    {
        protected IMarsPhotoService nasaService = null;

        public ExploreController()
        {
            if (null == nasaService)
            {
                nasaService = new MarsPhotoService();
            }
        }
        public ExploreController(IMarsPhotoService marsPhotoService) : this()
        {
            nasaService = marsPhotoService;
        }

        // GET: Explore
        public ActionResult Index()
        {
            var queryParams = new MarsRoverPhotosQueryViewModel();
            // queryParams.ApiKey = nasaService.
            //queryParams.ApiKey = "1234";
            return View(queryParams);
        }

        [HttpGet]
        public async Task<ActionResult> Load(MarsRoverPhotosQueryViewModel queryParams)
        {
            ////temp hard-code some stuff to test
            //queryParams.Rover = MarsRoverEnum.Curiosity;
            //queryParams.Camera = MarsRoverCameraEnum.FHAZ;

            var queryObj = MarsPhotoService.FromViewModel(queryParams);
            var apiData = await nasaService.GetFirstPhoto(queryObj);
            return View(apiData);
        }
    }
}