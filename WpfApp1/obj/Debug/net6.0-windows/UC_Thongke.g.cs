﻿#pragma checksum "..\..\..\UC_Thongke.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "854A648509CFBC5502924CF0EA52B793471CF87C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Do_an;
using LiveCharts.Wpf;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Do_an {
    
    
    /// <summary>
    /// UC_Thongke
    /// </summary>
    public partial class UC_Thongke : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\UC_Thongke.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart barChart;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\UC_Thongke.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\UC_Thongke.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_thang;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\UC_Thongke.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_nam;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\UC_Thongke.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblOption;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\UC_Thongke.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblChonThang;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\UC_Thongke.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblChonNam;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Do_an;component/uc_thongke.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UC_Thongke.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.barChart = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            case 2:
            this.cb = ((System.Windows.Controls.ComboBox)(target));
            
            #line 28 "..\..\..\UC_Thongke.xaml"
            this.cb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cb_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cb_thang = ((System.Windows.Controls.ComboBox)(target));
            
            #line 42 "..\..\..\UC_Thongke.xaml"
            this.cb_thang.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cb_thang_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cb_nam = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.lblOption = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lblChonThang = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lblChonNam = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            
            #line 68 "..\..\..\UC_Thongke.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnThongKe_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

