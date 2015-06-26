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
    /// ViewModel of the AlbumTracksView Which display tracks according to a specific album
    /// </summary>
    class AlbumTracksViewModel : ViewModelBase {
        public Api.Util.Device Device { get; private set; }

        public string ArtistName { get; private set; }
        public string AlbumName { get; private set; }
        public List<Track> AlbumTracks { get; private set; }

        /// <summary>
        /// Constructor also checks if CurrentArtist is null and if it is we can retrieve it with his ID which Album provides
        /// </summary>
        public AlbumTracksViewModel() {

            try {
                AlbumName = client.CurrentAlbum.Name;
                AlbumTracks = client.DeviceGetTracksFromAlbum(client.CurrentDevice.Id, client.CurrentAlbum.Id);
                Artist artist = client.DevicesGetArtist(client.CurrentAlbum.ArtistId);
                if (ArtistName == null || artist.Name != client.CurrentArtist.Name) {
                    client.CurrentArtist = artist;
                }
                ArtistName = client.CurrentArtist.Name;
            } catch (Exception ex) {
                App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                App.Navigation.PopAsync();
            }
            

            SelectTrackCommand = new Command<string>(execute: (string trackName) => {
                try {
                    client.CurrentTrack = (from item in AlbumTracks
                                           where item.Name == trackName
                                           select item).First();
                    App.Navigation.PushAsync(new TrackPlayerPage());
                } catch (Exception ex) {
                    App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                    
                }
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
