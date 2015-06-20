using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MusicPickerApp.ViewModels {
    public class AddDeviceViewModel : ViewModelBase{

        public string DeviceName {
            get;
            set;
        }
        public string DevicePassword {
            get;
            set;
        }
        public AddDeviceViewModel() {
            AddNewDeviceCommand = new Command(execute: () => {
                //Add new Device with name and pwd
            });

        }
        public ICommand AddNewDeviceCommand {
            get;
            private set;
        }
    }
}
