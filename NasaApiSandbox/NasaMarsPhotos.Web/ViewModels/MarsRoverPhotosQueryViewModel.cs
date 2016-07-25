using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasaMarsPhotos.Web.ViewModels
{
    public class MarsRoverPhotosQueryViewModel
    {
        public MarsRoverPhotosQueryViewModel()
        {
            //populate some default values
            Rover = "Curiosity";
            Camera = "MAST";
            Page = 1;
            MissionSol = 100;
        }

        public string Rover { get; set; }

        public string Camera { get; set; }
        
        public int Page { get; set; }

        public int? MissionSol { get; set; }

        public DateTime? EarthDate { get; set; }
    }
}