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
            ActivateItemAsync(new AppConfigurationViewModel(), new System.Threading.CancellationToken());
            _windowState = WindowState.Maximized;
        } 
 
        public async Task InstallService()
        {
            await ActivateItemAsync(new InstallViewModel(), new System.Threading.CancellationToken());
        }
        public async Task UnInstallService()
        {
            await ActivateItemAsync(new UninstallViewModel(), new System.Threading.CancellationToken());
        }

        public async Task StartService()
        {
            await ActivateItemAsync(new StartViewModel(), new System.Threading.CancellationToken());
        }
        
        public async Task StopService()
        {
            await ActivateItemAsync(new StopViewModel(), new System.Threading.CancellationToken());
        }

        public async Task CheckServiceStatus()
        {
            await ActivateItemAsync(new CheckStatusViewModel(), new System.Threading.CancellationToken());
        }
        
        public async Task ConfigruationSetting()
        {
            await ActivateItemAsync(new AppConfigurationViewModel(), new System.Threading.CancellationToken());
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
