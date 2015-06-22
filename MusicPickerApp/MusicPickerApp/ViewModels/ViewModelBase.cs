using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MusicPickerApp.Api;

namespace MusicPickerApp.ViewModels {
    /// <summary>
    /// Base ViewModel for the Data Binding
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        protected ApiClient client = ApiClient.Instance;

        protected bool SetProperty<T>(ref T storage, T value,
                                      [CallerMemberName] string propertyName = null) {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
