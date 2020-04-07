using Caliburn.Micro;
using System;
using System.Configuration;
using System.IO;
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
         
        public string ServiceInstallationDirectory{ get; set; }
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
                if (!Directory.Exists(ServiceInstallerDirectory))
                {
                    SetResutlText($".Exe file location doesnot exist  \n >>>> {ServiceInstallerDirectory}");
                    return;
                }
                else
                {
                    if (!Directory.Exists(ServiceInstallationDirectory))
                    {
                        Directory.CreateDirectory(ServiceInstallationDirectory);
                    }

                    SetResutlText($"Copying file to install directory");
                    //Now Create all of the directories
                    foreach (string dirPath in Directory.GetDirectories(ServiceInstallerDirectory, "*",
                        SearchOption.AllDirectories))
                        Directory.CreateDirectory(dirPath.Replace(ServiceInstallerDirectory, ServiceInstallationDirectory));

                    //Copy all the files & Replaces any files with the same name
                    foreach (string newPath in Directory.GetFiles(ServiceInstallerDirectory, "*.*",
                        SearchOption.AllDirectories))
                        File.Copy(newPath, newPath.Replace(ServiceInstallerDirectory, ServiceInstallationDirectory), true);
                    SetResutlText($"Copy file completed");

                }

                SetResutlText("Service installation begin");

                var arguments = "-i";
                var filename = System.IO.Path.Combine(ServiceInstallationDirectory, "HotBagWebPrinting.exe");
                SetResutlText(ProcessHelpers.RunExternalExe(filename, arguments, true)); 
                SetResutlText("Installation Completed");
                 
                //Starting Service
                SetResutlText($"\n===== Starting service started =====", true);
                string cmd = $"/k net start HotBagWebPrinting";
                SetResutlText(ProcessHelpers.RunCmd(cmd, true));
                SetResutlText($"\n===== Starting service ended =====", true);

            }
            catch (Exception ex)
            {
                SetResutlText($"{ex}");
            }
            SetResutlText($"\n===== Installing service ended =====", true); 
        }
          
        public void SelectInstallerDirectory()
        {
           
        }

        private void SetResutlText(string text, bool isHeader = false)
        {
            var a = isHeader ? "\n" + text.ToUpper() + "\n" : text;
            ResultViewer += $"\t{a} \n";
        }
    }
}
