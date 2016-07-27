﻿using NasaMarsPhotos.Web.Services;
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
            return View(queryParams);
        }
    }
}