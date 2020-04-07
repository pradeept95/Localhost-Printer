using Caliburn.Micro;
using WPFUI.Helpers;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    public class AppConfigurationViewModel : Screen
    {
        private ApplicationConfigurationModel _appConfig;
        public ApplicationConfigurationModel AppConfig
        {
            get
            {
                return _appConfig;
            }
            set
            {
                _appConfig = value;
                NotifyOfPropertyChange(() => AppConfig.ServiceName);
            }
        }

        public AppConfigurationViewModel()
        {
            ResetForm();
        }  

        public void UpdateConfig()
        {
            AppSettingHelper.UpdateAppSetting(AppConfig);
        }

        public void ResetToDefault()
        {
            AppSettingHelper.ScafoldAppConfig(true);
        }

        public void ResetForm()
        {
            var setting = ApplicationConfig.Instance;
            _appConfig = new ApplicationConfigurationModel
            {
                InstallationLocation = setting.Settings.InstallationLocation,
                InstallerLocation = setting.Settings.InstallerLocation,
                PrinterSettingDirectory = setting.Settings.PrinterSettingDirectory,
                ServiceDisplayName = setting.Settings.ServiceDisplayName,
                ServiceName = setting.Settings.ServiceName
            };
        }
    }
}
