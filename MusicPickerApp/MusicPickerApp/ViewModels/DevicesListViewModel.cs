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
        public DevicesListViewModel() {
           DeviceList = client.DevicesGet();
            AddDevicePageCommand = new Command(execute: () => {
                App.Navigation.PushAsync(new AddDevicePage());
            });

        }
        public ICommand AddDevicePageCommand {
            get;
            private set;
        }

    }
}
