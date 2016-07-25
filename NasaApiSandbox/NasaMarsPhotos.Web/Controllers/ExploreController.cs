using NasaMarsPhotos.DataService;
using NasaMarsPhotos.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NasaMarsPhotos.Web.Controllers
{
    public class ExploreController : Controller
    {
        protected NasaMarsRoverPhotoService nasaService = new NasaMarsRoverPhotoService();

        // GET: Explore
        public ActionResult Index()
        {
            var queryParams = new MarsPhotoQueryParameters();
            // queryParams.ApiKey = nasaService.
            queryParams.ApiKey = "1234";
            return View(queryParams);
        }
    }
}