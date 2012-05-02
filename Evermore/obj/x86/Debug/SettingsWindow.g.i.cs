﻿#pragma checksum "..\..\..\SettingsWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A63E037EE5354D2CEB92AED0AA464C04"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
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
using System.Windows.Data;
using System.Windows.Documents;
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


namespace Evermore {
    
    
    /// <summary>
    /// SettingsWindow
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class SettingsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 77 "..\..\..\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MaxRecusionDepth;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IgnoreDirectory;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddDir;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView IgnoreDirsList;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RemoveDir;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveSettings;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelSettings;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Evermore;component/settingswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\SettingsWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MaxRecusionDepth = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.IgnoreDirectory = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.AddDir = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\SettingsWindow.xaml"
            this.AddDir.Click += new System.Windows.RoutedEventHandler(this.AddDir_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.IgnoreDirsList = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.RemoveDir = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\SettingsWindow.xaml"
            this.RemoveDir.Click += new System.Windows.RoutedEventHandler(this.RemoveDir_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SaveSettings = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\..\SettingsWindow.xaml"
            this.SaveSettings.Click += new System.Windows.RoutedEventHandler(this.SaveSettings_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CancelSettings = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\..\SettingsWindow.xaml"
            this.CancelSettings.Click += new System.Windows.RoutedEventHandler(this.CancelSettings_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

