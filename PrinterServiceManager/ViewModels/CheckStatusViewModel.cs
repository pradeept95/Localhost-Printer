using Caliburn.Micro;
using WPFUI.Helpers;

namespace WPFUI.ViewModels
{
    public class CheckStatusViewModel : Screen
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

        public CheckStatusViewModel()
        {

        }

        public void ServiceCheckStatus()
        {
            SetResutlText($"\n===== Getting service status started =====", true); 
            string cmd = $"/k sc query HotBagWebPrinting";
            SetResutlText(ProcessHelpers.RunCmd(cmd, true));
            SetResutlText($"\n===== Getting service status ended =====", true);
        }

        private void SetResutlText(string text, bool isHeader = false)
        {
            var a = isHeader ? "\n" + text.ToUpper() + "\n" : text;
            ResultViewer += $"\t{a} \n";
        }
    }
}
