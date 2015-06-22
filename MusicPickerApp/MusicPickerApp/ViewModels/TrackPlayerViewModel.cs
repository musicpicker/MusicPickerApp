using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MusicPickerApp.ViewModels {
    class TrackPlayerViewModel : ViewModelBase {
        public Api.Util.Device Device { get; private set; }

        public string ArtistName { get; private set; }
        public string TrackName { get; private set; }
        public string AlbumName { get; private set; }
        public string DeviceName {get; private set;}

        public TrackPlayerViewModel() {

            DeviceName = client.CurrentDevice.Name;
            ArtistName = client.CurrentArtist.Name;
            TrackName = client.CurrentTrack.Name;
            AlbumName = client.CurrentAlbum.Name;

            

        }
    }
}
