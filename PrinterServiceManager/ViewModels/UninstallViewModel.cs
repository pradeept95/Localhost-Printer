using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.Helpers;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    public class UninstallViewModel : Screen
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

        public UninstallViewModel()
        {
            setting = ApplicationConfig.Instance;

        }

        public void UnInstallService()
        {
            SetResutlText($"\n===== Uninstalling service started =====", true);
            string cmd = $"/k sc delete {setting.Settings.ServiceName}";
            SetResutlText(ProcessHelpers.RunCmd(cmd, true));
            SetResutlText($"\n===== Uninstalling service ended =====", true);
        }

        private void SetResutlText(string text, bool isHeader = false)
        {
            var a = isHeader ? "\n" + text.ToUpper() + "\n" : text;
            ResultViewer += $"\t{a} \n";
        }
    }
}
