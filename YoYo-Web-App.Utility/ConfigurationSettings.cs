using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Configuration;
using System.IO;

namespace YoYo_Web_App.Utility
{
    public class ConfigurationSettings : IConfigurationSettings
    {
        private readonly string beepTestFilePath;
        private readonly string athletesFilePath;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;

        public ConfigurationSettings(IHostingEnvironment hostingEnvironment,IConfiguration configuration)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
            this.beepTestFilePath = this.ReadSettings("BeepTestFilePath");
            this.athletesFilePath = this.ReadSettings("AthletesFilePath");
        }

        public string BeepTestFilePath => Path.Combine(this.hostingEnvironment.WebRootPath, this.beepTestFilePath);

        public string AthletesFilePath => Path.Combine(this.hostingEnvironment.WebRootPath, this.athletesFilePath);

        public string ReadSettings(string key)
        {
            string result = string.Empty;
            try
            {
                result = this.configuration.GetSection(key).Value;
            }
            catch (Exception)
            {
                throw new Exception("Configuration Not Found");
            }

            return result;
        }
    }
}
