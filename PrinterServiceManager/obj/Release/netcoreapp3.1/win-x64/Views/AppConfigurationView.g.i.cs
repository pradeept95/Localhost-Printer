﻿#pragma checksum "..\..\..\..\..\Views\AppConfigurationView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65DF5813FE95393159D51DF66AB854B08E480541"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WPFUI.Views;


namespace WPFUI.Views {
    
    
    /// <summary>
    /// AppConfigurationView
    /// </summary>
    public partial class AppConfigurationView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 42 "..\..\..\..\..\Views\AppConfigurationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AppConfig_ServiceName;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\..\Views\AppConfigurationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AppConfig_ServiceDisplayName;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\..\Views\AppConfigurationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AppConfig_InstallerLocation;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\..\Views\AppConfigurationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AppConfig_InstallationLocation;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\..\Views\AppConfigurationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AppConfig_PrinterSettingDirectory;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\..\Views\AppConfigurationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateConfig;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\..\..\Views\AppConfigurationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ResetForm;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\..\..\Views\AppConfigurationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ResetToDefault;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HotBag.AspNetCore.PrinterServiceManager;component/views/appconfigurationview.xam" +
                    "l", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\AppConfigurationView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.AppConfig_ServiceName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.AppConfig_ServiceDisplayName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.AppConfig_InstallerLocation = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.AppConfig_InstallationLocation = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.AppConfig_PrinterSettingDirectory = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.UpdateConfig = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.ResetForm = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.ResetToDefault = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

