using App1.Entity;
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
        private string ApiUrl = "https://2-dot-backup-server-003.appspot.com/_api/v2/songs/post-free";
        public Upload()
        {
            this.InitializeComponent();
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
            }else if (!this.Link.Text.EndsWith(".mp3"))
            {
                this.erroLink.Text = "Link must be mp3";
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
                var httpClient = new HttpClient();
                //httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
                HttpContent content = new StringContent(JsonConvert.SerializeObject(newSong), Encoding.UTF8, "application/json");

                //Task<HttpResponseMessage> httpRequestMessage = httpClient.PostAsync(ApiUrl, content);
                String responseContent = httpClient.PostAsync(ApiUrl, content).Result.Content.ReadAsStringAsync().Result;
                Debug.WriteLine("Response: " + responseContent);
            }

        }
    }
}
