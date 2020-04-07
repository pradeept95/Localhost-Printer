using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.Models;

namespace WPFUI.Helpers
{
    public static class AppSettingHelper
    {
        public static bool SetAppSettings<TType>(string key, TType value)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                    return false;

                Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                AppSettingsSection appSettings = (AppSettingsSection)appConfig.GetSection("appSettings");
                if (appSettings.Settings[key] == null)
                    appSettings.Settings.Add(key, value.ToString());
                else
                    appSettings.Settings[key].Value = value.ToString();
                appConfig.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            catch
            {
                return false;
            }
        } 

        public static TType GetAppSettings<TType>(string key, TType defaultValue = default(TType))
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                    return defaultValue;
                AppSettingsReader appSettings = new AppSettingsReader();
                return (TType)appSettings.GetValue(key, typeof(TType));
            }
            catch
            {
                return defaultValue;
            }
        }
         
        public static void ScafoldAppConfig(bool isSetToDefault = false)
        {
            if (string.IsNullOrEmpty(GetAppSettings<string>("ServiceDisplayName")) || isSetToDefault)
            {
                var defaultConfiguration = new ApplicationConfigurationModel().GetDefalultApplicationConfiguration();

                if (!string.IsNullOrEmpty(defaultConfiguration.ServiceDisplayName)) 
                    SetAppSettings<string>("ServiceDisplayName", defaultConfiguration.ServiceDisplayName);

                if (!string.IsNullOrEmpty(defaultConfiguration.ServiceName))
                    SetAppSettings<string>("ServiceName", defaultConfiguration.ServiceName);

                if (!string.IsNullOrEmpty(defaultConfiguration.InstallationLocation))
                    SetAppSettings<string>("InstallationLocation", defaultConfiguration.InstallationLocation);

                if (!string.IsNullOrEmpty(defaultConfiguration.InstallerLocation))
                    SetAppSettings<string>("InstallerLocation", defaultConfiguration.InstallerLocation);

                if (!string.IsNullOrEmpty(defaultConfiguration.PrinterSettingDirectory)) 
                    SetAppSettings<string>("PrinterSettingDirectory", defaultConfiguration.PrinterSettingDirectory);
            }
        }

        public static void UpdateAppSetting(ApplicationConfigurationModel model)
        {
            SetAppSettings<string>("ServiceDisplayName", model.ServiceDisplayName);
            SetAppSettings<string>("ServiceName", model.ServiceName);
            SetAppSettings<string>("InstallationLocation", model.InstallationLocation);
            SetAppSettings<string>("InstallerLocation", model.InstallerLocation);
            SetAppSettings<string>("PrinterSettingDirectory", model.PrinterSettingDirectory);

            //update applicaton Setting
            var setting = ApplicationConfig.Instance;
            setting.UpdateSetting();
        }

    }
}
