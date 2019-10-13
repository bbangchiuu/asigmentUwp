using App1.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyInfo : Page
    {
        private MemberService memberService;

        public MyInfo()
        {

            this.InitializeComponent();
            memberService = new MemberServiceImp();
            var member = memberService.GetInformation();
                Debug.WriteLine(member);

                this.PersonPicture.ProfilePicture = new BitmapImage(new Uri(member.avatar));
                this.Name.Text = member.lastName + " " + member.firstName;
                if (member.gender == 1)
                {
                    this.Gender.Text = "Male";
                }
                else
                {
                    this.Gender.Text = "Female";
                }

                this.email.Text = member.email;
                this.Address.Text = member.address;
                this.Birthday.Text = member.birthday;
                this.Phone.Text = member.phone;
                this.introduction.Text = member.introduction;
                this.loginRequied.Visibility = Visibility.Collapsed;
            
        }

        private void ButtonLogin_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Login));
        }

        private void ButtonRegister_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Register));
        }
    }
}
