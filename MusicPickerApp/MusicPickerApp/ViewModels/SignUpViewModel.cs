using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MusicPickerApp.ViewModels {
    class SignUpViewModel : ViewModelBase {
        private string name;
        private string password;
        private string cpassword;

        public SignUpViewModel() {
            RegisterCommand = new Command(execute: () => {
                //Add new Device with name and pwd

                //at the end
                /*if(failedconnection)
                 * App.Current.MainPage.DisplayAlert("Error,"Your login name or password doesnt exits","Ok")*/
                Name = Password = "";
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
