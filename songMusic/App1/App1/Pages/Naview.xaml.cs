using App1.Entity;
using App1.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Naview : Page
    {
        public static Boolean isUser = false;
        public static Frame MainFrame;
        public static NavigationViewItem loginNaviewItem;
        public static NavigationViewItem registerNaviewItem;

        public static NavigationViewItem uploadNaviewItem;
        public static NavigationViewItem myinfoNaviewItem;
        public static NavigationViewItem logoutNaviewItem;
        public static NavigationViewItem mysongNaviewItem;

        private MemberServiceImp memberService;
        public Naview()
        {
            this.InitializeComponent();
            MainFrame = this.ContentFrame;

            loginNaviewItem = this.Login;
            registerNaviewItem = this.Regsiter;

            uploadNaviewItem = this.UploadSong;
            myinfoNaviewItem = this.MyInfor;
            logoutNaviewItem = this.LogoutUser;
            mysongNaviewItem = this.MySong;

            memberService = new MemberServiceImp();
          
        }
        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        // List of ValueTuple holding the Navigation Tag and the relative Navigation Page
        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        {
            ("listsong", typeof(Pages.ListSong)),
            ("login", typeof(Pages.Login)),
            ("register", typeof(Pages.Register)),
            ("upload", typeof(Pages.Upload)),
            ("myinfo", typeof(Pages.MyInfo)),
            ("mysong", typeof(Pages.MySong)),

        };

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
           
            // Add handler for ContentFrame navigation.
            //ContentFrame.Navigated += On_Navigated;

            // NavView doesn't load any page by default, so load home page.
            NavView.SelectedItem = NavView.MenuItems[0];
            // If navigation occurs on SelectionChanged, this isn't needed.
            // Because we use ItemInvoked to navigate, we need to call Navigate
            // here to load the home page.
            Member member = memberService.GetInformation();
            if (member != null)
            {
                Debug.WriteLine("login sucsses");
                isUser = true;               

                MainFrame.Navigate(typeof(Pages.MyInfo));

                MemberServiceImp.isUSer();
            }
            else
            {
                NavView_Navigate("listsong", new EntranceNavigationTransitionInfo());
            }          
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked == true)
            {
                NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
            }
            else if (args.InvokedItemContainer != null)
            {
                var navItemTag = args.InvokedItemContainer.Tag.ToString();
                NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
            }
        }

        private void NavView_Navigate(string navItemTag, NavigationTransitionInfo transitionInfo)
        {
            Type _page = null;
            if (navItemTag == "settings")
            {
                _page = typeof(MainPage);
            }
            else
            {
                var item = _pages.FirstOrDefault(p => p.Tag.Equals(navItemTag));
                _page = item.Page;
            }

            if(navItemTag == "logout")
            {
                Debug.WriteLine("log out");
                memberService.logout();
                isUser = false;

                MemberServiceImp.isUSer();
                
            }

            // Get the page type before navigation so you can prevent duplicate
            // entries in the backstack.
            var preNavPageType = ContentFrame.CurrentSourcePageType;

            // Only navigate if the selected page isn't currently loaded.
            if (!(_page is null) && !Type.Equals(preNavPageType, _page))
            {
                ContentFrame.Navigate(_page, null, transitionInfo);
            }
        }

        private void On_Navigated(object sender, NavigationEventArgs e)
        {
            NavView.IsBackEnabled = ContentFrame.CanGoBack;

            if (ContentFrame.SourcePageType == typeof(MainPage))
            {
                // SettingsItem is not part of NavView.MenuItems, and doesn't have a Tag.
                NavView.SelectedItem = (NavigationViewItem)NavView.SettingsItem;
                NavView.Header = "Settings";
            }
            else if (ContentFrame.SourcePageType != null)
            {
                var item = _pages.FirstOrDefault(p => p.Page == e.SourcePageType);

                NavView.SelectedItem = NavView.MenuItems.OfType<NavigationViewItem>().First(n => n.Tag.Equals(item.Tag));

                NavView.Header = ((NavigationViewItem)NavView.SelectedItem)?.Content?.ToString();
            }
        }
    }
}
