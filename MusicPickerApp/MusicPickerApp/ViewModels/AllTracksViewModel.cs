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
    public class AllTracksViewModel : ViewModelBase {

        public List<Track> TracksList { get; private set; }
         

        public AllTracksViewModel() {
            //client.CurrentDevice.Id
            TracksList = client.DeviceGetTracks(1);

        }
    }
}
