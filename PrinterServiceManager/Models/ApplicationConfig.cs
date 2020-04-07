using WPFUI.Helpers;

namespace WPFUI.Models
{
    public sealed class ApplicationConfig
    {
        /*
        * Private property initilized with null
        * ensures that only one instance of the object is created
        * based on the null condition
        */
        private static ApplicationConfig instance = null;

        /*
       * public property is used to return only one instance of the class
       * leveraging on the private property
       */
        public static ApplicationConfig Instance
        {
            get
            {
                if (instance == null)
                    instance = new ApplicationConfig();
                return instance;
            }
        }

        /*
        * Private constructor ensures that object is not
        * instantiated other than with in the class itself
        */
        private ApplicationConfig()
        {
            _appConfig = new ApplicationConfigurationModel
            {
                PrinterSettingDirectory = AppSettingHelper.GetAppSettings<string>("PrinterSettingDirectory"),
                InstallerLocation = AppSettingHelper.GetAppSettings<string>("InstallerLocation"),
                InstallationLocation = AppSettingHelper.GetAppSettings<string>("InstallationLocation"),
                ServiceDisplayName = AppSettingHelper.GetAppSettings<string>("ServiceDisplayName"),
                ServiceName = AppSettingHelper.GetAppSettings<string>("ServiceName")
            };
        }

        private ApplicationConfigurationModel _appConfig;

        public ApplicationConfigurationModel Settings
        {
            get { return this._appConfig; }
        }

        /*
          * Public method which can be invoked through the singleton instance to set new value to config property
      */

        public void UpdateSetting()
        {
            this._appConfig = new ApplicationConfigurationModel
            {
                PrinterSettingDirectory = AppSettingHelper.GetAppSettings<string>("PrinterSettingDirectory"),
                InstallerLocation = AppSettingHelper.GetAppSettings<string>("InstallerLocation"),
                InstallationLocation = AppSettingHelper.GetAppSettings<string>("InstallationLocation"),
                ServiceDisplayName = AppSettingHelper.GetAppSettings<string>("ServiceDisplayName"),
                ServiceName = AppSettingHelper.GetAppSettings<string>("ServiceName")
            };
        }
    }

}
