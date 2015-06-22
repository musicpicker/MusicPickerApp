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
        public Api.Util.Device Device { get; private set; }
        public Artist Artist { get; private set; }
        public string ArtistName { get; private set; }
        public List<Album> ArtistAlbums { get; private set; }
        public ArtistsAlbumsViewModel() {


            Device = client.CurrentDevice;
            Artist = client.CurrentArtist;
            ArtistName = Artist.Name;
            ArtistAlbums = client.DeviceGetAlbumsFromArtist(Device.Id, Artist.Id);


            SelectAlbumCommand = new Command<string>(execute: (string albumName) => {
                client.CurrentAlbum = (from item in ArtistAlbums
                                       where item.Name == albumName
                                       select item).First();
                App.Navigation.PushAsync(new AlbumTracksPage());
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
