using Caliburn.Micro;
using WPFUI.Helpers;

namespace WPFUI.ViewModels
{
    public class StartViewModel : Screen
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

        public StartViewModel()
        {

        }

        public void StartService()
        {
            SetResutlText($"\n===== Starting service started =====", true); 
            string cmd = $"/k net start HotBagWebPrinting";
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
