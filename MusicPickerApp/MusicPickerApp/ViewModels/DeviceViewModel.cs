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

            Device = client.CurrentDevice;

            client.connectToHub();

            DisplayPollPageCommand = new Command(execute: () => {
                App.Navigation.PushAsync(new PollPage());
            });
            SelectArtistCommand = new Command<string>(execute: (string artistName) => {
                client.CurrentArtist = (from item in allArtistsViewModel.ArtistsList
                                        where item.Name == artistName
                                        select item).First();
                App.Navigation.PushAsync(new ArtistAlbumsPage());
            });

            SelectAlbumCommand = new Command<string>(execute: (string albumName) => {
                client.CurrentAlbum = (from item in allAlbumsViewModel.AlbumsList
                                       where item.Name == albumName
                                       select item).First();
                App.Navigation.PushAsync(new AlbumTracksPage());
            });
            SelectTrackCommand = new Command<string>(execute: (string trackName) => {
                client.CurrentTrack = (from item in allTracksViewModel.TracksList
                                       where item.Name == trackName
                                       select item).First();
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
