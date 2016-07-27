namespace NasaMarsPhotos.Web.Services
{
    public interface IWebConfigAccessor
    {
        bool HasAppSettingsKey(string key);
        string ReadAppSettingsValue(string key, string defaultValue = "");
    }
}