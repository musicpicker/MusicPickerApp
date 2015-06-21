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
    class ArtistsAlbumsViewModel : ViewModelBase {
        public Api.Util.Device Device { get; set; }
        public Artist Artist { get; set; }
        public List<Album> ArtistAlbums { get; set; }
        public ArtistsAlbumsViewModel() {
            client.LogIn("Tom", "isen59");
            List<Api.Util.Device> devices = client.DevicesGet();
            Device = devices[0];
            ArtistAlbums = client.DeviceGetAlbumsFromArtist(Device.Id, "Kontinuum");

            DisplayPollPageCommand = new Command(execute: () => {
                App.Navigation.PushAsync(new PollPage());
            });
            SelectArtistCommand = new Command<string>(execute: (string artistName) => {
                App.Navigation.PushAsync(new ArtistAlbumsPage());
            });
            SelectAlbumCommand = new Command<string>(execute: (string albumName) => {
                App.Navigation.PushAsync(new AlbumTracksPage());
            });
            SelectTrackCommand = new Command<string>(execute: (string trackName) => {
                App.Navigation.PushAsync(new TrackPlayerPage());
            });


        }
        public ICommand DisplayPollPageCommand {
            get;
            private set;
        }
        public ICommand SelectAlbumCommand {
            get;
            private set;
        }

        public ICommand SelectArtistCommand {
            get;
            private set;
        }
        public ICommand SelectTrackCommand {
            get;
            private set;
        }

    }
}
