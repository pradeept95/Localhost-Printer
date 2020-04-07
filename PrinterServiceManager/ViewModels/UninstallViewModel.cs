using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.Helpers;

namespace WPFUI.ViewModels
{
    public class UninstallViewModel : Screen
    {
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
            
        }

        public void UnInstallService()
        {
            SetResutlText($"\n===== Uninstalling service started =====", true); 
            string cmd = $"/k sc delete HotBagWebPrinting";
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
