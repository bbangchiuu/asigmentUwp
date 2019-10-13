using App1.Constant;
using App1.Entity;
using App1.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.UI.Popups;
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
    public sealed partial class Register : Page
    {
        private StorageFile photo;
        private string imgUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTO6b8UmHNot4Ra90A75-m6yRyuI03Q9SgvHgyiwsxHJIXXxJcL";

        private MemberService memberService;
        private int gender = -1;
        public Register()
        {
            this.InitializeComponent();
            memberService = new MemberServiceImp();
            
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var newMember = new Member()
            {
                firstName = this.firstname.Text,
                lastName = this.lastname.Text,
                avatar = this.imgUrl,
                phone = this.phone.Text,
                password = this.password.Password,
                address = this.address.Text,
                introduction = this.introduction.Text,
                birthday = this.Birthday.Date.ToString("yyyy-MM-dd"),
                email = this.email.Text,
                gender = this.gender,
            };

            //validate
            Dictionary<string, string> errors = newMember.ValidateData();
            if(errors.Count == 0)
            {
                memberService.logout();
                var member = memberService.Register(newMember);
                if (member != null)
                {
                    MemberServiceImp.isUSer();
                }
                else
                {
                   
                }
            }
            else
            {
                Debug.WriteLine("erroi register");
                if (errors.ContainsKey("firstname"))
                {
                    this.firstname_er.Text = errors["firstname"];
                }
                else
                {
                    this.firstname_er.Text = "";
                }

                if (errors.ContainsKey("lastname"))
                {
                    this.lastname_er.Text = errors["lastname"];
                }
                else
                {
                    this.lastname_er.Text = "";
                }

                if (errors.ContainsKey("address"))
                {
                    this.address_er.Text = errors["address"];
                }
                else
                {
                    this.address_er.Text = "";
                }

                if (errors.ContainsKey("password"))
                {
                    this.password_er.Text = errors["password"];
                }
                else
                {
                    this.password_er.Text = "";
                }

                if (errors.ContainsKey("introduction"))
                {
                    this.introduction_er.Text = errors["introduction"];
                }
                else
                {
                    this.introduction_er.Text = "";
                }

                if (errors.ContainsKey("phone"))
                {
                    this.phone_er.Text = errors["phone"];
                }
                else
                {
                    this.phone_er.Text = "";
                }

                if (errors.ContainsKey("email"))
                {
                    this.email_er.Text = errors["email"];
                }
                else
                {
                    this.email_er.Text = "";
                }
                //this.birthday_er.Text = errors["birthday"];  
                //this.gender_er.Text = errors["gender"];
            }
            
        }
        private void Gender_Checked(object sender, RoutedEventArgs e)
        {
            var gender_checked = (RadioButton) sender;

            if (gender_checked != null)
            {
                if (gender_checked.Tag.Equals("gender0"))
                {
                    this.gender = 0;
                }else if (gender_checked.Tag.Equals("gender1"))
                {
                    this.gender = 1;
                }               
            }
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {

        }

        private async void Button_Photo(object sender, RoutedEventArgs e)
        {           
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);

            this.photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if (this.photo == null)
            {
                // User cancelled photo capture
                return;
            }

            HttpUploadFile(memberService.GetUploadAvatarUrl(), "myFile", "image/png");
        }
        public async void HttpUploadFile(string url, string paramName, string contentType)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";

            Stream rs = await wr.GetRequestStreamAsync();
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string header = string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n", paramName, "path_file", contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            // write file.
            Stream fileStream = await this.photo.OpenStreamForReadAsync();
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);

            WebResponse wresp = null;
            try
            {
                wresp = await wr.GetResponseAsync();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);        
                string imageUrl = reader2.ReadToEnd();
                Debug.WriteLine(imageUrl);
                Avatar.Source = new BitmapImage(new Uri(imageUrl, UriKind.Absolute));
                imgUrl = imageUrl;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error uploading file", ex.StackTrace);
                Debug.WriteLine("Error uploading file", ex.InnerException);
                if (wresp != null)
                {
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }
        }
    }
}
