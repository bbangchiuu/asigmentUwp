using App1.Constant;
using App1.Entity;
using App1.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class MySong : Page
    {
        private bool _isPlaying;
        private int _currentIndex = 0;

        private ObservableCollection<Music> listMusic { get; set; }
        MemberServiceImp memberService;
        public MySong()
        {
            this.InitializeComponent();
            memberService = new MemberServiceImp();
            this.listMusic = new ObservableCollection<Music>();

            var token = memberService.ReadTokenFromLocalStorage();
            
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            String responseContent = httpClient.GetAsync(ApiUrl.GET_MY_SONG_URL).Result.Content.ReadAsStringAsync().Result;

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

        private void PreviousButton_OnClick(object sender, RoutedEventArgs e)
        {
            _currentIndex--;
            if (_currentIndex < 0)
            {
                _currentIndex = listMusic.Count - 1;
            }
            else if (_currentIndex >= listMusic.Count)
            {
                _currentIndex = 0;
            }
            Play();
        }

        private void NextButton_OnClick(object sender, RoutedEventArgs e)
        {
            _currentIndex++;
            if (_currentIndex >= listMusic.Count || _currentIndex < 0)
            {
                _currentIndex = 0;
            }
            Play();
        }

        private void SelectSong(object sender, TappedRoutedEventArgs e)
        {
            var selectItem = sender as StackPanel;
            MyMediaPlayer.Pause();
            if (selectItem != null)
            {
                if (selectItem.Tag is Music currentSong)
                {
                    Debug.WriteLine("Tag of selectItem: " + selectItem.Tag);

                    _currentIndex = listMusic.IndexOf(currentSong);
                    MyMediaPlayer.Source = new Uri(currentSong.link);
                    Play();
                }
            }
        }

        private void StatusButton_OnClick(object sender, RoutedEventArgs e)
        {

            if (_isPlaying)
            {
                Pause();
            }
            else
            {
                Play();
            }
        }

        private void Pause()
        {
            ControlLabel.Text = "Pause";
            MyMediaPlayer.Pause();
            StatusButton.Icon = new SymbolIcon(Symbol.Play);
            _isPlaying = false;
        }

        private void Play()
        {
            MyMediaPlayer.Source = new Uri(listMusic[_currentIndex].link);
            ControlLabel.Text = "Now Playing: " + listMusic[_currentIndex].name;
            ListViewSong.SelectedIndex = _currentIndex;
            MyMediaPlayer.Play();
            StatusButton.Icon = new SymbolIcon(Symbol.Pause);
            _isPlaying = true;
        }
    }
}
