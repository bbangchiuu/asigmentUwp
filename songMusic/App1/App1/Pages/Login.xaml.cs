using App1.Constant;
using App1.Entity;
using App1.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        private MemberService memberSerice;
        public Login()
        {
            this.InitializeComponent();
            memberSerice = new MemberServiceImp();
        }
        private void PassportSignInButton_Click(object sender, RoutedEventArgs e)
        {
            MemberLogin memberLogin = new MemberLogin
            {
                email = this.emailLogin.Text,
                password = this.passwordLogin.Password
            };

            Dictionary<string, string> errors = memberLogin.ValidateData();
            //validate
            if (errors != null)
            {
                if (memberSerice.Login(memberLogin) != null)
                {
                    this.login_er.Visibility = Visibility.Collapsed;
                    Naview.isUser = true;
                    MemberServiceImp.isUSer();
                }
                else
                {
                    this.login_er.Text = "Wrong login information!";
                    this.login_er.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (errors.ContainsKey("introduction"))
                {
                    this.emailLogin_er.Text = errors["introduction"];
                    this.emailLogin_er.Visibility = Visibility.Visible;
                }
                else
                {
                    this.emailLogin_er.Visibility = Visibility.Collapsed;
                }

                if (errors.ContainsKey("introduction"))
                {
                    this.passwordLogin_er.Text = errors["introduction"];
                    this.emailLogin_er.Visibility = Visibility.Visible;
                }
                else
                {
                    this.passwordLogin_er.Text = "";
                    this.emailLogin_er.Visibility = Visibility.Collapsed;
                }
            }
            
        }

        private void RegisterButtonTextBlock_OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.Register));
        }
    }
}
