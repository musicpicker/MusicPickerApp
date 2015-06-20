using MusicPickerApp.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MusicPickerApp.ViewModels {
    public class LoginViewModel : ViewModelBase {
        private string name;
        private string password;
        private bool isLoading = false;
        public bool IsLoading {
            get {
                return isLoading;
            }
            set {
                isLoading = value;
            }
        }

        public LoginViewModel() {
            SignUpCommand = new Command(execute: () => {
                App.Navigation.PushAsync(new SignUpPage());

            });
            LoginCommand = new Command(execute: () => {
                IsLoading = true;

                //async getToken(name,password)
                //if(sucess)
                //App.Navigation.PushAsync(new DevicesPage());
                /*while (IsLoading) {
                
                }*/
                // Name = Password = ""
                List<DeviceView> Devices = new List<DeviceView>();
                Devices.Add(new DeviceView("Device 1",true));
                Devices.Add(new DeviceView("Device 2", false));
                Devices.Add(new DeviceView("Device 3", false));
                Devices.Add(new DeviceView("Device 4", true));
                Devices.Add(new DeviceView("Device 5", false));
                Devices.Add(new DeviceView("Device 6", false));

                App.Navigation.PushAsync(new DevicesListPage(Devices));
                
            });

        }
        public string Name {
            set {
                SetProperty(ref name, value);
            }
            get {
                return name;
            }
        }
        public string Password {
            set {
                SetProperty(ref password, value);
            }
            get {
                return password;
            }
        }
        public ICommand LoginCommand {
            get;
            private set;
        }
        public ICommand SignUpCommand {
            get;
            private set;
        }



    }
}