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
    /// ViewModel of the ArtistsAlbums Page Which display albums according to a specific artist.
    /// </summary>
    class ArtistsAlbumsViewModel : ViewModelBase {
        public Api.Util.Device Device { get; private set; }
        public Artist Artist { get; private set; }
        public string ArtistName { get; private set; }
        public List<Album> ArtistAlbums { get; private set; }
        public ArtistsAlbumsViewModel() {

            try {
                Device = client.CurrentDevice;
                Artist = client.CurrentArtist;
                ArtistName = Artist.Name;
                ArtistAlbums = client.DeviceGetAlbumsFromArtist(Device.Id, Artist.Id);

            } catch (Exception ex) {
                App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                
            }
            SelectAlbumCommand = new Command<string>(execute: (string albumName) => {
                try {
                    client.CurrentAlbum = (from item in ArtistAlbums
                                           where item.Name == albumName
                                           select item).First();
                    App.Navigation.PushAsync(new AlbumTracksPage());
                } catch (Exception ex) {
                    App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                }
            });
            DisplayPollPageCommand = new Command(execute: () => {
                App.Navigation.PushAsync(new PollPage());
            });


        }
        public ICommand SelectAlbumCommand {
            get;
            private set;
        }
        public ICommand DisplayPollPageCommand { get; private set; }
    }
}
