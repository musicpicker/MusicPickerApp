using MusicPickerApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using MusicPickerApp.Api;

namespace MusicPickerApp
{
    public partial class App : Application
    {
        
        public App()
        {
            // The root page of your application
            InitializeComponent();
            NavigationPage rootPage;
            if (Properties.ContainsKey("bearer")) {
                ApiClient.Instance.ProvideBearer(App.Current.Properties["bearer"] as string);
                rootPage = new NavigationPage((new DevicesListPage()));
            } else {
                
                rootPage = new NavigationPage(new LoginPage());
            }
           
            //ToolBar Color For Android
            rootPage.BarBackgroundColor = Color.FromHex("#387C13");
            MainPage = rootPage;
            App.Navigation = rootPage.Navigation;
            
        }
        public static INavigation Navigation {
            get;
            set;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            App.Current.Properties["bearer"] = ApiClient.Instance.RetrieveBearer();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
             ApiClient.Instance.ProvideBearer(App.Current.Properties["bearer"] as string);
        }
    }
}
