﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MusicPickerApp.ViewModels {
    /// <summary>
    /// ViewModel of the AddDevicePage, adds a device from the form entry and send it to the server
    /// </summary>
    public class AddDeviceViewModel : ViewModelBase{
        private string deviceName;
        
        public AddDeviceViewModel() {
            AddNewDeviceCommand = new Command(execute: () => {
                //Add new Device with name and pwd

                try {
                    if (client.DeviceAdd(deviceName) != -1) {
                        App.Current.MainPage.DisplayAlert("Sucess", "A new Device has been added to your list ! Please reload the App", "Ok");
                        

                    }
                } catch (Exception ex){
                    App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                } finally {
                    DeviceName = "";
                    App.Navigation.PopAsync();
                }
                
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
