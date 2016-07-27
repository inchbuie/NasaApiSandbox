using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NasaMarsPhotos.Web.Models
{
    public class NasaMarsRoverPhoto
    {
        public int Id { get; set; }

        public int Sol { get; set; }

        public NasaMarsRoverSelectedCamera Camera { get; set; }

        [Display(Name = "Image (click to embiggen)")]
        public string Img_Src { get; set; }

        public DateTime EarthDate { get; set; }

        public NasaMarsRover Rover { get; set; }
    }
}