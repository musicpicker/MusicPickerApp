﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MusicPickerApp.Views;
using Xamarin.Forms;

namespace MusicPickerApp.ViewModels {
    /// <summary>
    /// ViewModel of the Sign Up
    /// Gets data from the form and send it to the server to register the new user and establish a connexion.
    /// </summary>
    class SignUpViewModel : ViewModelBase {
        private string name;
        private string password;
        private string cpassword;
        /// <summary>
        /// When the log in is successful, the bearer is stored in App.Properties
        /// Which can be used at the launch of the app
        /// </summary>
        public SignUpViewModel() {
            RegisterCommand = new Command(execute: () => {

                if (password == cpassword) {
                    try {

                    
                    if (client.SignUp(name, password)) {
                        App.Current.MainPage.DisplayAlert("Sucess", "Your inscription is done !", "Ok");
                        client.LogIn(name, password);
                        App.Current.Properties["bearer"] = client.RetrieveBearer();
                        App.Navigation.PushAsync(new DevicesListPage());
                    } else {
                        App.Current.MainPage.DisplayAlert("Error", "Your inscription is not correct please retry", "Ok");
                    }
                    } catch (Exception e) {

                        App.Current.MainPage.DisplayAlert("Error", e.Message, "Ok");
                    }
                } else {
                    App.Current.MainPage.DisplayAlert("Error", "Your password is not the same on the two entries", "Ok");
                }
                
                Name = Password = CPassword = "";
            });

        }
        public string Name {
            get {
                return name;
            }
            set {
                SetProperty(ref name, value);
            }
        }
        public string Password {
            get {
                return password;
            }
            set {
                SetProperty(ref password, value);
            }
        }
        public string CPassword {
            get {
                return cpassword;
            }
            set {
                SetProperty(ref cpassword, value);
            }
        }

        public ICommand RegisterCommand {
            get;
            private set;
        }

    }
}
