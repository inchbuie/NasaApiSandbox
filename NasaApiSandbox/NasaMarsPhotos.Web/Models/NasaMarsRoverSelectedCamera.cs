using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NasaMarsPhotos.Web.Models
{
    public class NasaMarsRoverSelectedCamera
    {
        public int Id { get; set; }

        [Display(Name = "Camera")]
        public string Name { get; set; }

        public int Rover_Id { get; set; }

        [Display(Name = "Camera Full Name")]
        public string FullName { get; set; }
    }
}