using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasaMarsPhotos.Web.Models
{
    public class NasaMarsRover
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LandingDate { get; set; }
        public int MaxSol { get; set; }
        public DateTime MaxDate { get; set; }
        public int TotalPhotos { get; set; }
        public virtual ICollection<NasaMarsRoverAvailableCamera> Cameras { get; set; }
    }
}