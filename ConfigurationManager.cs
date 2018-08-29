using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace RX
{
    public class ConfigurationManager
    {
        private static IConfigurationRoot config = null;
        static ConfigurationManager()
        {
            // Microsoft.Extensions.Configuration扩展包提供的
            /*
             使用方式：ConfigurationManager.AppSettings["db"]
             appsetting.json格式：{ "db": "Data Source=.;Initial Catalog=test;User ID=sa;Password=123456" }
             */
            var builder = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json"));
            config = builder.Build();
        }

        public static IConfigurationRoot AppSettings
        {
            get
            {
                return config;
            }
        }

        public static string Get(string key)
        {
            return config[key];
        }

    }
}
