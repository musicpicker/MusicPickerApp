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
        private ApiClient client;
        public App()
        {
            // The root page of your application
            InitializeComponent();
            NavigationPage rootPage;
            if (Properties.ContainsKey("bearer")) {
                /*if (client.LogIn(name, password)) {
                        List<DeviceView> DevicesView = new List<DeviceView>();
                        List<MusicPickerApp.Api.Util.Device> list = client.DevicesGet();
                        foreach (var device in list) {
                            DevicesView.Add(new DeviceView(device.Name, true));
                        }*/
                rootPage = new NavigationPage(); //(new DevicesListPage(DevicesView))
            } else {
                rootPage = new NavigationPage(new LoginPage());
            }
           
            //ToolBar For Android
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
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
