using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Networking.Connectivity;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using News.Helpers;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace News
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private bool _backButtonClicked;
        public bool BackButtonClicked
        {
            get { return _backButtonClicked; }
            set
            {
                if(_backButtonClicked != value)
                {
                    _backButtonClicked = value;
                    OnPropertyChanged("BackButtonClicked");
                }
            }
        }
        public MainPage()
        {
            this.InitializeComponent();

            //Design for TitleBar
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.CompactOverlay;

            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(800, 800));

            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.BackgroundColor = Windows.UI.ColorHelper.FromArgb(1, 67, 234, 165);
            titleBar.ButtonBackgroundColor = ColorHelper.FromArgb(1, 67, 234, 165);

            //Is App connected to network
            //var profile = NetworkInformation.GetInternetConnectionProfile();
            //bool isConnected = profile.GetNetworkConnectivityLevel() != NetworkConnectivityLevel.None;

            BackButtonClicked = ConstantHelper.IsBackButtonClicked;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private void nvTopLevelNav_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (NavigationViewItemBase item in nvTopLevelNav.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "Page1")
                {
                    nvTopLevelNav.SelectedItem = item;
                    break;
                }
            }
            contentFrame.Navigate(typeof(TodayPage));
        }

        private void nvTopLevelNav_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
        }

        private void nvTopLevelNav_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {

            if (args.IsSettingsInvoked)
            {
                contentFrame.Navigate(typeof(SettingsPage));
            }           
            else
            {
                var itemContent = args.InvokedItemContainer;
                if (itemContent != null)
                {
                    switch (itemContent.Tag)
                    {
                        case "Page1":
                            contentFrame.Navigate(typeof(TodayPage));
                            break;

                        case "Page2":
                            contentFrame.Navigate(typeof(InterestsPage));
                            break;

                        case "Page3":
                            contentFrame.Navigate(typeof(SourcesPage));
                            break;
                    }
                }
            }
        }

        private void NvTopLevelNav_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            contentFrame.Navigate(typeof(SourcesPage));
        }

        
    }
}
