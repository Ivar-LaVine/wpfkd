﻿#pragma checksum "..\..\..\Pages\DoctorsPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42656A91D0943B0E4BB3604EB8D3EF9DFE9D2AD2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DentalCabinetWPF.Pages;
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


namespace DentalCabinetWPF.Pages {
    
    
    /// <summary>
    /// DoctorsPage
    /// </summary>
    public partial class DoctorsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\Pages\DoctorsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel DataStackPanel;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Pages\DoctorsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddDoctorButton;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Pages\DoctorsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditDoctorButton;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Pages\DoctorsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteDoctorButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Pages\DoctorsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SearchComboBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Pages\DoctorsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchTextBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Pages\DoctorsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DoctorsDataGrid;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Pages\DoctorsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridSplitter DialogGridSplitter;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Pages\DoctorsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame DialogFrame;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DentalCabinetWPF;component/pages/doctorspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\DoctorsPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.DataStackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.AddDoctorButton = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\Pages\DoctorsPage.xaml"
            this.AddDoctorButton.Click += new System.Windows.RoutedEventHandler(this.AddDoctorButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.EditDoctorButton = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\Pages\DoctorsPage.xaml"
            this.EditDoctorButton.Click += new System.Windows.RoutedEventHandler(this.EditDoctorButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DeleteDoctorButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\Pages\DoctorsPage.xaml"
            this.DeleteDoctorButton.Click += new System.Windows.RoutedEventHandler(this.DeleteDoctorButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SearchComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.SearchTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\..\Pages\DoctorsPage.xaml"
            this.SearchTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DoctorsDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            
            #line 39 "..\..\..\Pages\DoctorsPage.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.AddDoctorButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 40 "..\..\..\Pages\DoctorsPage.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.EditDoctorButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 41 "..\..\..\Pages\DoctorsPage.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteDoctorButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.DialogGridSplitter = ((System.Windows.Controls.GridSplitter)(target));
            return;
            case 12:
            this.DialogFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

