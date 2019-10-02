﻿using App1.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class ListSong : Page
    {
        private const string ApiUrl = "https://2-dot-backup-server-003.appspot.com/_api/v2/songs/get-free-songs";
        private ObservableCollection<Music> listMusic { get; set; }

        public ListSong()
        {
            this.InitializeComponent();
            this.listMusic = new ObservableCollection<Music>();
            var httpClient = new HttpClient();
            //Task<HttpResponseMessage> httpRequestMessage = httpClient.GetAsync(ApiUrl);
            String responseContent = httpClient.GetAsync(ApiUrl).Result.Content.ReadAsStringAsync().Result;

            Debug.WriteLine(responseContent);

            List<Music> listSong = JsonConvert.DeserializeObject<List<Music>>(responseContent);
            foreach (Music item in listSong)
            {
                this.listMusic.Add(new Music()
                {
                    name = item.name,
                    singer = item.singer,
                    thumbnail = item.thumbnail,
                    link = item.link,
                });
            }
        }
    }
}
