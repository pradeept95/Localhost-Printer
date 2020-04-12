using Caliburn.Micro;
using WPFUI.Helpers;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    public class StartViewModel : Screen
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

        public StartViewModel()
        {
            setting = ApplicationConfig.Instance;
        }

        public void StartService()
        {
            SetResutlText($"\n===== Starting service started =====", true); 
            string cmd = $"/k net start {setting.Settings.ServiceName}";
            SetResutlText(ProcessHelpers.RunCmd(cmd, true));
            SetResutlText($"\n===== Starting service ended =====", true);
        }

        private void SetResutlText(string text, bool isHeader = false)
        {
            var a = isHeader ? "\n" + text.ToUpper() + "\n" : text;
            ResultViewer += $"\t{a} \n";
        }
    }
}
