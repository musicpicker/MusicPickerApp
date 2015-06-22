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

    public class DeviceViewModel : ViewModelBase {
        public Api.Util.Device Device { get; set; }

        private AllArtistsViewModel allArtistsViewModel;
        private AllAlbumsViewModel allAlbumsViewModel;
        private AllTracksViewModel allTracksViewModel;


        public DeviceViewModel() {
            client.LogIn("Tom", "isen59");
            Device = client.CurrentDevice = client.DevicesGet()[0];
            //Device = client.CurrentDevice;
            DisplayPollPageCommand = new Command(execute: () => {
                App.Navigation.PushAsync(new PollPage());
            });
            SelectArtistCommand = new Command<int>(execute: (int artistId) => {
                client.CurrentArtist = allArtistsViewModel.ArtistsList[artistId - 1];
                App.Navigation.PushAsync(new ArtistAlbumsPage());
            });

            SelectAlbumCommand = new Command<int>(execute: (int albumId) => {
                client.CurrentAlbum = allAlbumsViewModel.AlbumsList[albumId - 1];
                App.Navigation.PushAsync(new AlbumTracksPage());
            });
            SelectTrackCommand = new Command<int>(execute: (int trackId) => {
                client.CurrentTrack = allTracksViewModel.TracksList[trackId - 1];
                App.Navigation.PushAsync(new TrackPlayerPage());
            });


        }

        public void AddSubViewModel(AllArtistsViewModel artistsViewModel, AllAlbumsViewModel albumsViewModel, AllTracksViewModel tracksViewModel) {
            allAlbumsViewModel = albumsViewModel;
            allArtistsViewModel = artistsViewModel;
            allTracksViewModel = tracksViewModel;
        }
        public ICommand DisplayPollPageCommand {
            get;
            private set;
        }
        public ICommand SelectArtistCommand {
            get;
            private set;
        }
        public ICommand SelectAlbumCommand {
            get;
            private set;
        }

        public ICommand SelectTrackCommand {
            get;
            private set;
        }

    }
}
