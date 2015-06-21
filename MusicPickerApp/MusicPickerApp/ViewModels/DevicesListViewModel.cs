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
        public List<MusicPickerApp.Api.Util.Device> DeviceList { get; set; }
        private MusicPickerApp.Api.Util.Device currentDeviceSelected { get; set; }
        public DevicesListViewModel() {
           DeviceList = client.DevicesGet();
            AddDevicePageCommand = new Command(execute: () => {
                App.Navigation.PushAsync(new AddDevicePage());
            });
            SelectDeviceCommand = new Command<string>(execute: (string deviceName) => {
                App.Navigation.PushAsync(new DevicePage());

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
