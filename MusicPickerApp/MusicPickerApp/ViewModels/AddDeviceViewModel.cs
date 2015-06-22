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

                if (client.DeviceAdd(deviceName) !=-1) {
                    App.Current.MainPage.DisplayAlert("Sucess", "A new Device has been added to your list !", "Ok");
                    App.Navigation.PopAsync();
                    
                }
                DeviceName = "";
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
        

        public ICommand AddNewDeviceCommand {
            get;
            private set;
        }
    }
}
