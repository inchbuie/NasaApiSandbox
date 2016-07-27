using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace NasaMarsPhotos.Web.Services
{
    /// <summary>
    /// mini-service for access web.config app settings 
    /// </summary>
    public class WebConfigAccessor : IWebConfigAccessor
    {
        public WebConfigAccessor()
        {

        }

        public virtual bool HasAppSettingsKey(string key)
        {
            var exists = false;
            if (!String.IsNullOrWhiteSpace(key))
            {
                exists = ConfigurationManager.AppSettings.AllKeys.Contains(key);
            }
            return exists;
        }

        public virtual string ReadAppSettingsValue(string key, string defaultValue="")
        {
            string value = defaultValue;
            if (this.HasAppSettingsKey(key))
            {
                value = ConfigurationManager.AppSettings[key];
            }
            return value;
        }
    }
}