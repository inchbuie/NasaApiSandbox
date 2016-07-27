using NasaMarsPhotos.Web.Models;
using System.Threading.Tasks;

namespace NasaMarsPhotos.Web.Services
{
    public interface IMarsPhotoService
    {
        bool CheckEndpointAvailability();
        Task<string> GetFirstPhoto(MarsPhotoQueryParameters queryParams);
    }
}