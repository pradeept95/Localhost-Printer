using Caliburn.Micro;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Text;
using WPFUI.Helpers;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    public class PrinterSetupViewModel : Screen
    {
        ApplicationConfig setting;
        private string _resultViewer;
        public string ResultViewer
        {
            get
            {
                return _resultViewer;
            }
            set
            {
                _resultViewer = value;
                NotifyOfPropertyChange(() => ResultViewer);
            }
        }

        public PrinterSetupViewModel()
        {
            setting = ApplicationConfig.Instance;
            GetAllPrinter();
            SetResutlText( $"\n\nCURRENT PRINTER : {GetCurrentPrinterName()}" );
        }


        private string _printerName;

        public string PrinterName
        {
            get { return _printerName; }
            set { 
                _printerName = value;
                NotifyOfPropertyChange(() => PrinterName);
            }
        }
        public List<string> PrinterList { get; set; }

        public void SetPrinterName()
        {
            //SetResutlText($"\n===== Starting service started =====", true);
            //string cmd = $"/k net start {setting.Settings.ServiceName}";
            //SetResutlText(ProcessHelpers.RunCmd(cmd, true));
            //SetResutlText($"\n===== Starting service ended =====", true);

            //selectedPrinter = printerList.Text as string;

            if (string.IsNullOrEmpty(_printerName))
            {
                SetResutlText("Please Select Printer");
                return;
            }

            if (!Directory.Exists(setting.Settings.PrinterSettingDirectory))
            {
                Directory.CreateDirectory(setting.Settings.PrinterSettingDirectory);
            }

            var filepath = System.IO.Path.Combine(setting.Settings.PrinterSettingDirectory, "Printer.dat");
            if (File.Exists(filepath))
            {
                File.Delete(filepath);

            }
            System.IO.File.WriteAllText(filepath, _printerName.Trim(), Encoding.ASCII);

            // Configure the message box to be displayed
            SetResutlText( $"Printer Configuration Successfully Completed.");
            SetResutlText( $"Printer Name: {_printerName}");
            SetResutlText( $"Configured Directory: {setting.Settings.PrinterSettingDirectory}");
        }

        public void GetAllPrinter()
        {
            PrinterList = new List<string>();

            //getting all printer 
            var printerQuery = new ManagementObjectSearcher("SELECT * from Win32_Printer");

            SetResutlText("Available Printers Are", true);

            int i = 1;
            foreach (var printer in printerQuery.Get())
            {
                var name = printer.GetPropertyValue("Name").ToString();
                PrinterList.Add(name);
                SetResutlText($"{i++}: {name}");

            } 
        }

        public string GetCurrentPrinterName()
        {
            string currentPrinterName = "";
            var filepath = System.IO.Path.Combine(setting.Settings.PrinterSettingDirectory, "Printer.dat");
            if (!File.Exists(filepath))
            { 
                return "No printer found"; 
            }
           return currentPrinterName = System.IO.File.ReadAllText(filepath, Encoding.ASCII);
        }

        private void SetResutlText(string text, bool isHeader = false)
        {
            var a = isHeader ? "\n" + text.ToUpper() + "\n" : text;
            ResultViewer += $"\t{a} \n";
        }
    }
}
