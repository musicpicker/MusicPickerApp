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
    /// ViewModel of the Device Page which display all data from the device in 3 tabs : Artists, Albums, Tracks
    /// Gets a reference on other ViewModels in order ot get their data.
    /// </summary>
    public class DeviceViewModel : ViewModelBase {
        public Api.Util.Device Device { get; set; }

        private AllArtistsViewModel allArtistsViewModel;
        private AllAlbumsViewModel allAlbumsViewModel;
        private AllTracksViewModel allTracksViewModel;


        public DeviceViewModel() {
            try {
                Device = client.CurrentDevice;

                client.ConnectToHub();
            } catch (Exception ex) {
                App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                App.Navigation.PopAsync();
            }

            DisplayPollPageCommand = new Command(execute: () => {
                App.Navigation.PushAsync(new PollPage());
            });
            SelectArtistCommand = new Command<string>(execute: (string artistName) => {
                try {
                    client.CurrentArtist = (from item in allArtistsViewModel.ArtistsList
                                            where item.Name == artistName
                                            select item).First();
                    App.Navigation.PushAsync(new ArtistAlbumsPage());
                } catch (Exception ex) {
                    App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                }
                
            });

            SelectAlbumCommand = new Command<string>(execute: (string albumName) => {
                try {
                    client.CurrentAlbum = (from item in allAlbumsViewModel.AlbumsList
                                           where item.Name == albumName
                                           select item).First();
                    App.Navigation.PushAsync(new AlbumTracksPage());
                } catch (Exception ex) {
                    App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                }
            });
            SelectTrackCommand = new Command<string>(execute: (string trackName) => {
                try {
                    client.CurrentTrack = (from item in allTracksViewModel.TracksList
                                           where item.Name == trackName
                                           select item).First();
                    App.Navigation.PushAsync(new TrackPlayerPage());
                } catch (Exception ex) {
                    App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                }
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
