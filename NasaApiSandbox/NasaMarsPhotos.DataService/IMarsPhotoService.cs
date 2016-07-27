using System.Threading.Tasks;

namespace NasaMarsPhotos.DataService
{
    public interface IMarsPhotoService
    {
        bool CheckEndpointAvailability();
        Task<string> GetFirstPhoto(MarsPhotoQueryParameters queryParams);
    }
}