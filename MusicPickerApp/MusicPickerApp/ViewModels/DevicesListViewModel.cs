using MusicPickerApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MusicPickerApp.ViewModels {
    /// <summary>
    /// ViewModel of the DeviceList Page Which display the devices owned by the account
    /// </summary>
    public class DevicesListViewModel : ViewModelBase {
        public List<MusicPickerApp.Api.Util.Device> DeviceList { get; private set; }

        public DevicesListViewModel() {
            try {
                DeviceList = client.DevicesGet();
            } catch (Exception ex) {
                try { 
                    App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                    App.Navigation.PopAsync();
                } catch (Exception e){ 
                    App.Navigation = new NavigationPage(new LoginPage()).Navigation; 
                }
                
            }
            AddDevicePageCommand = new Command(execute: () => {
                App.Navigation.PushAsync(new AddDevicePage());

            });
            SelectDeviceCommand = new Command<string>(execute: (string deviceName) => {
                try {
                    client.CurrentDevice = (from item in DeviceList
                                            where item.Name == deviceName
                                            select item).First();
                } catch (Exception ex) {
                    App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                }

                App.Navigation.PushAsync(new DevicePage());

            });
            DeleteDeviceCommand = new Command<int>(execute: (int deviceIdToDelete) => {
                try {
                    client.DeviceDelete(deviceIdToDelete);
                    DeviceList = client.DevicesGet();
                    App.Current.MainPage.DisplayAlert("Sucess", "Your device has been deleted please reload the app", "Ok");
                } catch (Exception ex) {
                    App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                }
            });
            LogOutCommand = new Command(execute: () => {
                client.LogOut();
                App.Current.MainPage = new LoginPage();

            });

        }
        public ICommand AddDevicePageCommand {
            get;
            private set;
        }
        public ICommand SelectDeviceCommand {
            get;
            private set;
        }
        public ICommand DeleteDeviceCommand {
            get;
            private set;
        }
        public ICommand LogOutCommand {
            get;
            private set;
        }


    }
}
