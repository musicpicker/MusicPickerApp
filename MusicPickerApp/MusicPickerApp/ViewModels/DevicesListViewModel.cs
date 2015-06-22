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
        public List<MusicPickerApp.Api.Util.Device> DeviceList { get; private set; }

        public DevicesListViewModel() {
            DeviceList = client.DevicesGet();
            AddDevicePageCommand = new Command(execute: () => {
                App.Navigation.PushAsync(new AddDevicePage());
            });
            SelectDeviceCommand = new Command<string>(execute: (string deviceName) => {
               client.CurrentDevice = (from item in DeviceList
                            where item.Name == deviceName
                            select item).First();
                
                App.Navigation.PushAsync(new DevicePage());

            });
            DeleteDeviceCommand = new Command<int>(execute: (int deviceIdToDelete) => {
                client.DeviceDelete(deviceIdToDelete);
                DeviceList = client.DevicesGet();
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


    }
}
