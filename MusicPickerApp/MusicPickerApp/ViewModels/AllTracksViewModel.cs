using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MusicPickerApp.Api.Util;
using MusicPickerApp.Views;
using Xamarin.Forms;

namespace MusicPickerApp.ViewModels {
    /// <summary>
    /// ViewModel use to display all the tracks located on the Device
    /// </summary>
    public class AllTracksViewModel : ViewModelBase {

        public List<Track> TracksList { get; private set; }
        public AllTracksViewModel() {
            try { TracksList = client.DeviceGetTracks(client.CurrentDevice.Id); } catch (Exception ex) {
                App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                App.Navigation.PopAsync();
            }

        }
    }
}
