using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Microsoft.Extensions.Primitives;
namespace Microsoft.Extensions.Configuration
{
    public static class DockerSwarm
    {
        private const string APPSETTINGS = "appsettings.json";
        /// <summary>
        /// default folder on UNIX contianers
        /// </summary>
        private const string UNIX_BASE_PATH = "/run/secrets/";
        /// <summary>
        /// default folder of secrets in WINDOWS containers
        /// </summary>
        private const string WINDOWS_BASE_PATH = @"C:\ProgramData\Docker\secrets\";
        public static IConfiguration UseSecret(this IConfiguration configuration)
        {
            var platform = Environment.OSVersion.Platform;
            //UNIX
            string basePath = $"{UNIX_BASE_PATH}";
            //WINDOWS
            if (platform == PlatformID.Win32NT)
            {
                basePath = $"{WINDOWS_BASE_PATH}";
            }
            if (File.Exists(Path.Combine(basePath , APPSETTINGS)))
            {
                configuration = new ConfigurationBuilder().SetBasePath(basePath).AddJsonFile(APPSETTINGS).Build();
            }
            return configuration;
        }
        public static IConfiguration UseSecret(this IConfiguration configuration , string basePath)
        {
            var platform = Environment.OSVersion.Platform;
            if (File.Exists(Path.Combine(basePath, APPSETTINGS)))
            {
                configuration = new ConfigurationBuilder().SetBasePath(basePath).AddJsonFile(APPSETTINGS).Build();
            }
            return configuration;
        }
        public static IConfiguration UseSecret(this IConfiguration configuration, string basePath , string fileName)
        {
            var platform = Environment.OSVersion.Platform;
            if (File.Exists(Path.Combine(basePath, fileName)))
            {
                configuration = new ConfigurationBuilder().SetBasePath(basePath).AddJsonFile(fileName).Build();
            }
            return configuration;
        }
    }

}
