using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMarsPhotos.DataService
{
    /// <summary>
    /// Main entry points for the data service
    /// </summary>
    public class MarsPhotoService : IMarsPhotoService
    {
        /// <summary>
        /// Attempts to ping (verify the ability to make a connection with)
        ///  the target endpoint
        /// </summary>
        /// <returns></returns>
        public bool CheckEndpointAvailability()
        {
            return false;
        }
    }
}
