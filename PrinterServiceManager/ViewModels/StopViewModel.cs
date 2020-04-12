using Caliburn.Micro;
using WPFUI.Helpers;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    public class StopViewModel : Screen
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

        public StopViewModel()
        {
            setting = ApplicationConfig.Instance;
        }

        public void StopService()
        {
            SetResutlText($"\n===== Stopping service started =====", true); 
            string cmd = $"/k net stop {setting.Settings.ServiceName}";
            SetResutlText(ProcessHelpers.RunCmd(cmd, true));
            SetResutlText($"\n===== Stopping service ended =====", true);
        }

        private void SetResutlText(string text, bool isHeader = false)
        {
            var a = isHeader ? "\n" + text.ToUpper() + "\n" : text;
            ResultViewer += $"\t{a} \n";
        }
    }
}
