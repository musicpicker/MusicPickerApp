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
    /// ViewModel of the Track Player Page Which display the player and allow the user to control the device with the app
    /// </summary>
    class TrackPlayerViewModel : ViewModelBase {
        public Api.Util.Device Device { get; private set; }

        public string ArtistName { get; private set; }
        public string TrackName { get; private set; }
        public string AlbumName { get; private set; }
        public string AlbumYear { get; private set; }
        public string DeviceName { get; private set; }
        public string Artwork { get; private set; }

        private bool isPlaying = false;
        public bool IsPlaying { get{return isPlaying;} 
            private set{
            isPlaying = value;
            IsPlayingText = isPlaying ? "Pause" : "Play";
        } }

        private string isPlayingText = "Play";
        public string IsPlayingText {
            get {
                return isPlayingText;
            }
            private set {
                SetProperty(ref isPlayingText, value);
            }
        }



        public TrackPlayerViewModel() {
            IsPlayingText = "Play";
            try {
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
            } catch (Exception ex) {
                App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                App.Navigation.PopAsync();
            }

            PreviousTrackCommand = new Command(execute: () => {
                //api.DevicePreviousTrack()
                //api.playTrack()
            });
            NextTrackCommand = new Command(execute: () => {
                try { client.NextTrack(); } catch (Exception ex){
                    App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                }
                
            });
            PlayResumeCommand = new Command(execute: () => {
                try {
                    if (isPlaying) {
                        client.PauseTrack();
                    } else {
                        client.PlayTrack();
                    }
                    IsPlaying = !isPlaying;
                } catch (Exception ex) {
                    App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                }
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
