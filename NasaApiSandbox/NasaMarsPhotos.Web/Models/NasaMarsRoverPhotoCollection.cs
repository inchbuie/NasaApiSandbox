using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasaMarsPhotos.Web.Models
{
    public class NasaMarsRoverPhotoCollection
    {
        public virtual ICollection<NasaMarsRoverPhoto> Photos { get; set; }
    }
}