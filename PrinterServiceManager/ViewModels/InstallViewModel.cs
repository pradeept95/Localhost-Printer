using Caliburn.Micro;
using System;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using WPFUI.Helpers;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    public class InstallViewModel : Screen
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

        public string ServiceInstallationDirectory { get; set; }
        public string ServiceInstallerDirectory { get; set; }

        public InstallViewModel()
        {
            setting = ApplicationConfig.Instance;
            ServiceInstallationDirectory = setting.Settings.InstallationLocation;
            ServiceInstallerDirectory = setting.Settings.InstallerLocation;
        }

        public void InstallService()
        {


            SetResutlText($"\n===== Installing service started =====", true); 
            try
            {
                CopyAndUnzipFile();
                SetResutlText("Service installation begin");

                string installer = GetInstaller();
                if (string.IsNullOrEmpty(installer))
                {
                    SetResutlText("No application found to install");
                    SetResutlText($"\n===== Installing service ended with error =====", true);
                    return;
                } 

                string cmd = GetInstallationCmd(installer);
                SetResutlText(ProcessHelpers.RunCmd(cmd, true)); 

            }
            catch (Exception ex)
            {
                SetResutlText($"{ex}");
            }
            SetResutlText($"\n===== Installing service ended =====", true);

            SetResutlText($"\n===== Starting service started =====", true);
            string startCmd = $"/k net start {setting.Settings.ServiceName}";
            SetResutlText(ProcessHelpers.RunCmd(startCmd, true));
            SetResutlText($"\n===== Starting service ended =====", true);
        }

        public string GetInstallationCmd(string exePath)
        {
            return $"/k sc.exe create {setting.Settings.ServiceName} binpath= {exePath} start=auto";
        }

        public string GetInstaller()
        {
            //finding .exe file
            string[] files = Directory.GetFiles(ServiceInstallationDirectory);
            return files.ToList().FirstOrDefault(x => x.Contains(".exe"));
        }

        private string _selectedFileName;

        public string SelectedFileName
        {
            get { return _selectedFileName; }
            set
            {
                _selectedFileName = value;
                NotifyOfPropertyChange(() => SelectedFileName);
            }
        }

        public void CopyAndUnzipFile()
        {

            if (!File.Exists(SelectedFileName))
            {
                SetResutlText($"Please select .Zip file to install");
                return;  
            } 

            if (Directory.Exists(ServiceInstallationDirectory))
            {
                DeleteDirectory(ServiceInstallationDirectory);
            }
            Directory.CreateDirectory(ServiceInstallationDirectory);


            foreach (ZipArchiveEntry entry in ZipFile.OpenRead(SelectedFileName).Entries)
            {
                var filePath = Path.Combine(ServiceInstallationDirectory, entry.FullName);
                SetResutlText($"Extracting and Copying File : {filePath}");

                entry.ExtractToFile(filePath);
            }

            SelectedFileName = "";
        }

        public static void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }


        public void SelectInstaller()
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".zip";
            //dlg.Filter = "Zip File (*.zip)";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                SelectedFileName = filename;
            }

        }

        private void SetResutlText(string text, bool isHeader = false)
        {
            var a = isHeader ? "\n" + text.ToUpper() + "\n" : text;
            ResultViewer += $"\t{a} \n";
        }
    }
}
