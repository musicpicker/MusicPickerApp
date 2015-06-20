using MusicPickerApp.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MusicPickerApp.Api;

namespace MusicPickerApp.ViewModels {
    public class LoginViewModel : ViewModelBase {
        private ApiClient client = new ApiClient(new Uri("http://localhost:50559"));
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
                if (name == "toto" && password == "toto") {
                    List<DeviceView> Devices = new List<DeviceView>();
                    List<MusicPickerApp.Api.Util.Device> list = client.DevicesGet();
                    Devices.Add(new DeviceView(list[0].Name, true));
                    Devices.Add(new DeviceView("Device 2", false));
                    Devices.Add(new DeviceView("Device 3", false));
                    Devices.Add(new DeviceView("Device 4", true));
                    Devices.Add(new DeviceView("Device 5", false));
                    Devices.Add(new DeviceView("Device 6", false));

                    App.Navigation.PushAsync(new DevicesListPage(Devices));
                } else {
                    App.Current.MainPage.DisplayAlert("Error", "Your login is incorrect or does not exit", "Ok");
                    
                }
                Name = Password = "";
                
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