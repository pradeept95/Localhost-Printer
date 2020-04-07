namespace WPFUI.Models
{
    public class ApplicationConfigurationModel
    {
        public string ServiceName { get; set; }
        public string ServiceDisplayName { get; set; }
        public string InstallerLocation { get; set; }
        public string InstallationLocation { get; set; }
        public string PrinterSettingDirectory { get; set; }

        public ApplicationConfigurationModel GetDefalultApplicationConfiguration()
        {
            return new ApplicationConfigurationModel
            {
                ServiceDisplayName = @"HotBag Web Printer",
                ServiceName = @"HotBagWebPrinterService",
                InstallationLocation = @"C:\temp\HotBag\WebPrintingService",
                InstallerLocation = @"C:\temp\HotBag\WebPrintingService",
                PrinterSettingDirectory = @"C:\temp\HotBag\PrinterConfig"

            };
        }

    }

}
