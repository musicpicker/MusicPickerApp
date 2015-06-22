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
    class AlbumTracksViewModel : ViewModelBase {
        public Api.Util.Device Device { get; private set; }

        public string ArtistName { get; private set; }
        public string AlbumName { get; private set; }
        public List<Track> AlbumTracks { get; private set; }
        public AlbumTracksViewModel() {

            AlbumName = client.CurrentAlbum.Name;
            AlbumTracks = client.DeviceGetTracksFromAlbum(client.CurrentDevice.Id, client.CurrentAlbum.Id);
            Artist artist = client.DevicesGetArtist(client.CurrentAlbum.ArtistId);
            if (ArtistName == null || artist.Name != client.CurrentArtist.Name) {
                client.CurrentArtist = artist;
            }
                ArtistName = client.CurrentArtist.Name;

            SelectTrackCommand = new Command<int>(execute: (int trackId) => {
                client.CurrentTrack = AlbumTracks[trackId - 1];
                App.Navigation.PushAsync(new TrackPlayerPage());
            });
            DisplayPollPageCommand = new Command(execute: () => {
                App.Navigation.PushAsync(new PollPage());
            });


        }
        public ICommand SelectTrackCommand {
            get;
            private set;
        }
        public ICommand DisplayPollPageCommand { get; private set; }
    }
}
