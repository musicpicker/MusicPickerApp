using MusicPickerApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MusicPickerApp.ViewModels {
    public class DevicesListViewModel : ViewModelBase {
        //public List<Api.Util.Device> DeviceList { get; set; }
        private List<DeviceListDebug> deviceList = new List<DeviceListDebug>();
        public List<DeviceListDebug> DeviceList { get { return deviceList; } set { deviceList = value; } }
        private Api.Util.Device currentDeviceSelected { get; set; }
        public DevicesListViewModel() {
            //DeviceList = client.DevicesGet();
            //DeviceList = new List<Api.Util.Device>();

            DeviceList.Add(new DeviceListDebug("Device 1"));
            DeviceList.Add(new DeviceListDebug("Device 2"));

            AddDevicePageCommand = new Command(execute: () => {
                App.Navigation.PushAsync(new AddDevicePage());
            });
            SelectDeviceCommand = new Command<string>(execute: (string deviceName) => {
                App.Current.MainPage.DisplayAlert("Error", deviceName, "Ok");

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


    }
}
