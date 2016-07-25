using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NasaMarsPhotos.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Information about the NASA Mars Rover Photos API Explorer website";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Information about the creator of the NASA Mars Rover Photos API Explorer website";

            return View();
        }
    }
}