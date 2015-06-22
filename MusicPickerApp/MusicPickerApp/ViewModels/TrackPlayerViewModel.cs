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
    class TrackPlayerViewModel : ViewModelBase {
        public Api.Util.Device Device { get; private set; }

        public string ArtistName { get; private set; }
        public string TrackName { get; private set; }
        public string AlbumName { get; private set; }
        public string AlbumYear { get; private set; }
        public string DeviceName { get; private set; }
        public string Artwork { get; private set; }

        public TrackPlayerViewModel() {

            TrackName = client.CurrentTrack.Name;
            Album album = client.DevicesGetAlbum(client.CurrentTrack.AlbumId);
            if (client.CurrentAlbum == null || album.Name != client.CurrentAlbum.Name) {
                client.CurrentAlbum = album;
            }
            AlbumYear = "(" + client.CurrentAlbum.Year + ")";
            AlbumName = client.CurrentAlbum.Name;

            Artist artist = client.DevicesGetArtist(client.CurrentAlbum.ArtistId);
            if (ArtistName == null || artist.Name != client.CurrentArtist.Name) {
                client.CurrentArtist = artist;
            }
            ArtistName = client.CurrentArtist.Name;
            DeviceName = client.CurrentDevice.Name;
            AlbumName = client.CurrentAlbum.Name;
            Artwork = client.CurrentAlbum.Artwork;

            PreviousTrackCommand = new Command(execute: () => {
                //api.DevicePreviousTrack()
                //api.playTrack()
            });
            NextTrackCommand = new Command(execute: () => {
                //api.DeviceNextTrack()
                //api.playTrack()
            });
            PlayResumeCommand = new Command(execute: () => {
                //api.playTrack()
                //api.resumeTrack()
            });
            DisplayPollPageCommand = new Command(execute: () => {
                App.Navigation.PushAsync(new PollPage());
            });

        }
        public ICommand PreviousTrackCommand {
            get;
            private set;
        }
        public ICommand NextTrackCommand {
            get;
            private set;
        }
        public ICommand PlayResumeCommand {
            get;
            private set;
        }
        public ICommand DisplayPollPageCommand {
            get;
            private set;
        }
    }
}
