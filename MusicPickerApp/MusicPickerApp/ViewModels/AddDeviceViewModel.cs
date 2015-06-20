using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MusicPickerApp.ViewModels {
    public class AddDeviceViewModel : ViewModelBase{
        private string deviceName;
        private string devicePwd;
        
        public AddDeviceViewModel() {
            AddNewDeviceCommand = new Command(execute: () => {
                //Add new Device with name and pwd

                //at the end
                /*if(failedconnection)
                 * App.Current.MainPage.DisplayAlert("Error,"Your login name or password doesnt exits","Ok")*/
                DeviceName = DevicePassword = "";
            });

        }
        public string DeviceName {
            get{
                return deviceName;
            }
            set {
                SetProperty(ref deviceName , value);
            }
        }
        public string DevicePassword {
            get{
                return devicePwd;
            }
            set {
                SetProperty(ref devicePwd, value);
            }
        }

        public ICommand AddNewDeviceCommand {
            get;
            private set;
        }
    }
}
