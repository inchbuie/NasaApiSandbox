using System.Threading.Tasks;

namespace NasaMarsPhotos.Web.Services
{
    public interface IMiniHttpClient
    {
        Task<T> MakeRequestGetJsonData<T>(string queryArgs);
    }
}