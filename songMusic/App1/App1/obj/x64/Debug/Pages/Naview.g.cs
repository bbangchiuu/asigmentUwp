﻿#pragma checksum "E:\Windows_Forms_Programming\songMusic\App1\App1\Pages\Naview.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0FE58BD0887174B9D296CF2619E6478D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App1.Pages
{
    partial class Naview : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Pages\Naview.xaml line 12
                {
                    this.NavView = (global::Windows.UI.Xaml.Controls.NavigationView)(target);
                    ((global::Windows.UI.Xaml.Controls.NavigationView)this.NavView).Loaded += this.NavView_Loaded;
                    ((global::Windows.UI.Xaml.Controls.NavigationView)this.NavView).ItemInvoked += this.NavView_ItemInvoked;
                }
                break;
            case 3: // Pages\Naview.xaml line 15
                {
                    this.Login = (global::Windows.UI.Xaml.Controls.NavigationViewItem)(target);
                }
                break;
            case 4: // Pages\Naview.xaml line 16
                {
                    this.Regsiter = (global::Windows.UI.Xaml.Controls.NavigationViewItem)(target);
                }
                break;
            case 5: // Pages\Naview.xaml line 17
                {
                    this.MyInfor = (global::Windows.UI.Xaml.Controls.NavigationViewItem)(target);
                }
                break;
            case 6: // Pages\Naview.xaml line 18
                {
                    this.MySong = (global::Windows.UI.Xaml.Controls.NavigationViewItem)(target);
                }
                break;
            case 7: // Pages\Naview.xaml line 19
                {
                    this.UploadSong = (global::Windows.UI.Xaml.Controls.NavigationViewItem)(target);
                }
                break;
            case 8: // Pages\Naview.xaml line 21
                {
                    this.LogoutUser = (global::Windows.UI.Xaml.Controls.NavigationViewItem)(target);
                }
                break;
            case 9: // Pages\Naview.xaml line 24
                {
                    this.ContentFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                    ((global::Windows.UI.Xaml.Controls.Frame)this.ContentFrame).NavigationFailed += this.ContentFrame_NavigationFailed;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

