using App1.Constant;
using App1.Entity;
using App1.Service;
using Newtonsoft.Json;
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
using Windows.UI.Popups;
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
    public sealed partial class Upload : Page
    {
        MemberServiceImp memberService;
        public Upload()
        {
            this.InitializeComponent();
            memberService = new MemberServiceImp();
        }
        private void Submit_OnClick(object sender, RoutedEventArgs e)
        {
            Boolean subName, subThubnail, subLink;
            subName = subThubnail = subLink = true;

            if (this.Name.Text.Equals(""))
            {
                this.erroName.Text = "Name is requaired!";
                subName = false;
            }
            else
            {
                this.erroName.Text = "";
                subName = true;
            }

            if (this.Thumbnail.Text.Equals(""))
            {
                this.erroThumbnail.Text = "Thumbnail is requaired!";
                subThubnail = false;
            }
            else
            {
                this.erroThumbnail.Text = "";
                subThubnail = true;
            }

            if (this.Link.Text.Equals(""))
            {
                this.erroLink.Text = "Link is requaired!";
                subLink = false;
            }
            else
            {
                this.erroLink.Text = "";
                subLink = true;
            }

            if (subName && subThubnail && subLink)
            {
                Music newSong = new Music()
                {
                    name = this.Name.Text,
                    description = this.Description.Text,
                    singer = this.Singer.Text,
                    author = this.Author.Text,
                    thumbnail = this.Thumbnail.Text,
                    link = this.Link.Text
                };

                string token = memberService.ReadTokenFromLocalStorage();

                var httpClient = new HttpClient();               
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
                HttpContent content = new StringContent(JsonConvert.SerializeObject(newSong), Encoding.UTF8, "application/json");
                String responseContent = httpClient.PostAsync(ApiUrl.SONG_URL, content).Result.Content.ReadAsStringAsync().Result;
                Debug.WriteLine("Response: " + responseContent);

                messageSuccess();
            }

        }

        private async void messageSuccess()
        {
            MessageDialog messageDialog = new MessageDialog("up load thanh cong", "Tile");
            await messageDialog.ShowAsync();
            this.Name.Text = "";
            this.Thumbnail.Text = "";
            this.Singer.Text = "";
            this.Link.Text = "";
            this.Author.Text = "";
        }
    }
}
