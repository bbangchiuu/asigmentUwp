using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using App1.Constant;
using App1.Entity;
using App1.Pages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Windows.UI.Xaml;

namespace App1.Service
{
    class MemberServiceImp : MemberService
    {
        public Member GetInformation()
        {
            string token = ReadTokenFromLocalStorage();
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            Task<HttpResponseMessage> httpRequestMessage = httpClient.GetAsync(ApiUrl.GET_INFORMATION_URL);
            String responseContent = httpRequestMessage.Result.Content.ReadAsStringAsync().Result;
            Debug.WriteLine("respon:  " + responseContent);
            //if(responseContent.)
            Member member = JsonConvert.DeserializeObject<Member>(responseContent);

            Debug.WriteLine("id:   " + member.id);
            if (string.IsNullOrEmpty(member.id)) {
                return null;
            }
            
            return member;
        }

        public static void isUSer()
        {
            if (Naview.isUser)
            {
                Naview.MainFrame.Navigate(typeof(Pages.MyInfo));

                Naview.loginNaviewItem.Visibility = Visibility.Collapsed;
                Naview.registerNaviewItem.Visibility = Visibility.Collapsed;

                Naview.myinfoNaviewItem.Visibility = Visibility.Visible;
                Naview.uploadNaviewItem.Visibility = Visibility.Visible;
                Naview.logoutNaviewItem.Visibility = Visibility.Visible;
                Naview.mysongNaviewItem.Visibility = Visibility.Visible;

            }
            else
            {
                Naview.MainFrame.Navigate(typeof(Pages.Login));

                Naview.loginNaviewItem.Visibility = Visibility.Visible;
                Naview.registerNaviewItem.Visibility = Visibility.Visible;

                Naview.myinfoNaviewItem.Visibility = Visibility.Collapsed;
                Naview.uploadNaviewItem.Visibility = Visibility.Collapsed;
                Naview.logoutNaviewItem.Visibility = Visibility.Collapsed;
                Naview.mysongNaviewItem.Visibility = Visibility.Collapsed;
            }
        }

        public string GetTokenFromLocalStorage()
        {
            throw new NotImplementedException();
        }

        public string GetUploadAvatarUrl()
        {
            HttpClient client = new HttpClient();
            string uploadUrl = client.GetAsync(ApiUrl.GET_URL_UPLOAD_AVATAR).Result.Content.ReadAsStringAsync().Result;
            Debug.WriteLine("Upload url: " + uploadUrl);

            return uploadUrl;
        }

        public string Login(MemberLogin memberLogin)
        {
            try
            {
                // lấy token từ api.
                var token = GetTokenFromApi(memberLogin);
                //lưu token ra file để dùng lại
                SaveTokenToLocalStorage(token);
                Debug.WriteLine("Login Success!!");
                return token;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        private String GetTokenFromApi(MemberLogin memberLogin)
        {
            // thực hiện request lên api lấy token về.
            HttpClient httpClient = new HttpClient();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(memberLogin), Encoding.UTF8, "application/json");
            var responseContent = httpClient.PostAsync(ApiUrl.LOGIN_URL, content).Result.Content.ReadAsStringAsync().Result;
            Debug.WriteLine("Response: " + responseContent);
            JObject jsonJObject = JObject.Parse(responseContent);

            if (jsonJObject["token"] == null)
            {
                
            }
            return jsonJObject["token"].ToString();
        }

        public void logout()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = storageFolder.CreateFileAsync("token.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting).GetAwaiter().GetResult();
            Windows.Storage.FileIO.WriteTextAsync(sampleFile, "").GetAwaiter().GetResult();
        }

        public Member Register(Member member)
        {
            var httpClient = new HttpClient();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(member), Encoding.UTF8, "application/json");
            string responseContent = httpClient.PostAsync(ApiUrl.REGISTER_URL, content).Result.Content.ReadAsStringAsync().Result;
            Debug.WriteLine("Response: " + responseContent);

            var resMember = JsonConvert.DeserializeObject<Member>(responseContent);
            return resMember;
        }

        private void SaveTokenToLocalStorage(string token)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile tokenFile = storageFolder.CreateFileAsync("token.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting).GetAwaiter().GetResult();
            Windows.Storage.FileIO.WriteTextAsync(tokenFile, token).GetAwaiter().GetResult();
        }

        public string ReadTokenFromLocalStorage()
        {
            try
            {
                Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile tokenFile = storageFolder.GetFileAsync("token.txt").GetAwaiter().GetResult();
                Debug.WriteLine(tokenFile.Path);
                var token = Windows.Storage.FileIO.ReadTextAsync(tokenFile).GetAwaiter().GetResult();
                return token;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
    }
}
