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
    /// <summary>
    /// ViewModel of the Login Page
    /// Gets data from the form and send it to the server to establish a connexion.
    /// </summary>
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
        /// <summary>
        /// When the log in is successful, the bearer is stored in App.Properties
        /// Which can be used at the launch of the app
        /// </summary>
        public LoginViewModel() {

            SignUpCommand = new Command(execute: () => {
                App.Navigation.PushAsync(new SignUpPage());

            });
            LoginCommand = new Command(execute: () => {
                IsLoading = true;

                
                try {


                    if (client.LogIn(name, password)) {
                        App.Current.Properties["bearer"] = client.RetrieveBearer();
                        App.Navigation.PushAsync(new DevicesListPage());
                    } else {
                        App.Current.MainPage.DisplayAlert("Error", "Your login is incorrect or does not exist", "Ok");

                    }
                } catch (Exception e) {

                    App.Current.MainPage.DisplayAlert("Error", e.Message, "Ok");
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