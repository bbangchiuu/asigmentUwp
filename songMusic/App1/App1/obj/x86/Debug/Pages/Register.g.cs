﻿#pragma checksum "E:\Windows_Forms_Programming\songMusic\App1\App1\Pages\Register.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9B5C3A101AD9FCED5D495CA0F78C68C8"
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
    partial class Register : 
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
            case 2: // Pages\Register.xaml line 38
                {
                    this.email = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // Pages\Register.xaml line 39
                {
                    this.email_er = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // Pages\Register.xaml line 41
                {
                    this.password = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 5: // Pages\Register.xaml line 42
                {
                    this.password_er = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // Pages\Register.xaml line 44
                {
                    this.address = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // Pages\Register.xaml line 45
                {
                    this.address_er = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // Pages\Register.xaml line 47
                {
                    this.introduction = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9: // Pages\Register.xaml line 48
                {
                    this.introduction_er = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10: // Pages\Register.xaml line 50
                {
                    this.phone = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 11: // Pages\Register.xaml line 51
                {
                    this.phone_er = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12: // Pages\Register.xaml line 78
                {
                    this.res_button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.res_button).Click += this.ButtonBase_OnClick;
                }
                break;
            case 13: // Pages\Register.xaml line 79
                {
                    global::Windows.UI.Xaml.Controls.Button element13 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element13).Click += this.Button_Cancel;
                }
                break;
            case 14: // Pages\Register.xaml line 65
                {
                    this.Birthday = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 15: // Pages\Register.xaml line 66
                {
                    this.birthday_er = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16: // Pages\Register.xaml line 74
                {
                    this.gender_er = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 17: // Pages\Register.xaml line 70
                {
                    global::Windows.UI.Xaml.Controls.RadioButton element17 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)element17).Checked += this.Gender_Checked;
                }
                break;
            case 18: // Pages\Register.xaml line 71
                {
                    global::Windows.UI.Xaml.Controls.RadioButton element18 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)element18).Checked += this.Gender_Checked;
                }
                break;
            case 19: // Pages\Register.xaml line 29
                {
                    this.firstname = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 20: // Pages\Register.xaml line 30
                {
                    this.firstname_er = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 21: // Pages\Register.xaml line 33
                {
                    this.lastname = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 22: // Pages\Register.xaml line 34
                {
                    this.lastname_er = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 23: // Pages\Register.xaml line 14
                {
                    this.button_cap = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.button_cap).Click += this.Button_Photo;
                }
                break;
            case 24: // Pages\Register.xaml line 15
                {
                    this.Avatar = (global::Windows.UI.Xaml.Controls.Image)(target);
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

