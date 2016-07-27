using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMarsPhotos.Web.Models
{
    /// <summary>
    /// Class encapsulating the parameters to be passed to the NASA web service
    /// </summary>
    public class MarsPhotoQueryParameters
    {
        public string RootPath { get; set; }

        public MarsRoverEnum Rover { get; set; }

        public MarsRoverCameraEnum Camera { get; set; }

        public string ApiKey { get; set; }

        public int Page { get; set; }

        public int? MissionSol { get; set; }

        public DateTime? EarthDate { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (!String.IsNullOrWhiteSpace(RootPath))
            {
                sb.Append('/');
                sb.Append(RootPath);
            }
            sb.Append('/');
            sb.Append(this.Rover.ToString().ToLower());
            sb.Append("/photos?");
            if (null!=EarthDate && EarthDate.HasValue)
            {
                sb.Append("earth_date=");
                sb.Append(this.EarthDate.Value.ToString("yyyy-M-dd"));
            }
            else
            {
                sb.Append("sol=");
                sb.Append(MissionSol.GetValueOrDefault(1));
            }
            sb.Append("&camera=");
            sb.Append(this.Camera.ToString().ToLower());
            if (this.Page > 1)
            {
                sb.Append("&page=");
                sb.Append(this.Page);
            }
            sb.Append("&api_key=");
            sb.Append(this.ApiKey);

            return sb.ToString();
        }
    }
}
