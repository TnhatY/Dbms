﻿#pragma checksum "..\..\..\..\UC_KhachHang\UC_KhachHang.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98B53FB33A58544ED42B7C264F9B838AE7DEE5D3"
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
    /// UC_KhachHang
    /// </summary>
    public partial class UC_KhachHang : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 180 "..\..\..\..\UC_KhachHang\UC_KhachHang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock makh;
        
        #line default
        #line hidden
        
        
        #line 181 "..\..\..\..\UC_KhachHang\UC_KhachHang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnThemkhachhang;
        
        #line default
        #line hidden
        
        
        #line 191 "..\..\..\..\UC_KhachHang\UC_KhachHang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtsdt;
        
        #line default
        #line hidden
        
        
        #line 193 "..\..\..\..\UC_KhachHang\UC_KhachHang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTimkiem;
        
        #line default
        #line hidden
        
        
        #line 194 "..\..\..\..\UC_KhachHang\UC_KhachHang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg_khachhang;
        
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
            System.Uri resourceLocater = new System.Uri("/Do_an;component/uc_khachhang/uc_khachhang.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UC_KhachHang\UC_KhachHang.xaml"
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
            
            #line 8 "..\..\..\..\UC_KhachHang\UC_KhachHang.xaml"
            ((Do_an.UC_KhachHang)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.makh = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.btnThemkhachhang = ((System.Windows.Controls.Button)(target));
            
            #line 181 "..\..\..\..\UC_KhachHang\UC_KhachHang.xaml"
            this.btnThemkhachhang.Click += new System.Windows.RoutedEventHandler(this.btnThemkhachhang_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtsdt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnTimkiem = ((System.Windows.Controls.Button)(target));
            
            #line 193 "..\..\..\..\UC_KhachHang\UC_KhachHang.xaml"
            this.btnTimkiem.Click += new System.Windows.RoutedEventHandler(this.btnTimkiem_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dg_khachhang = ((System.Windows.Controls.DataGrid)(target));
            
            #line 196 "..\..\..\..\UC_KhachHang\UC_KhachHang.xaml"
            this.dg_khachhang.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dg_khachhang_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

