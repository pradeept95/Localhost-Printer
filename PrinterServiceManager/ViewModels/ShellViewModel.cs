using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    { 

        private System.Windows.WindowState _windowState;

        public System.Windows.WindowState AppWindowState
        {
            get { return _windowState; }
            set {
                _windowState = value;
                NotifyOfPropertyChange(() => AppWindowState);
            }
        }
         
        public ShellViewModel()
        {
            ActivateItem(new AppConfigurationViewModel());
            _windowState = WindowState.Maximized;
        } 
 
        public void InstallService()
        {
            ActivateItem(new InstallViewModel());
        }
        public void UnInstallService()
        {
            ActivateItem(new UninstallViewModel());
        }

        public void StartService()
        {
            ActivateItem(new StartViewModel());
        }
        
        public void StopService()
        {
            ActivateItem(new StopViewModel());
        }

        public void CheckServiceStatus()
        {
            ActivateItem(new CheckStatusViewModel());
        }
        
        public void ConfigruationSetting()
        {
            ActivateItem(new AppConfigurationViewModel());
        }

        public void MinimizeWindow()
        {
            _windowState = WindowState.Minimized;
        }

        public void CloseWindow()
        {
            System.Windows.Application.Current.Shutdown(); 
        }

    }
}
