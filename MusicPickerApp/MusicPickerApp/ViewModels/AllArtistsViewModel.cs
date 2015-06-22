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
    public class AllArtistsViewModel : ViewModelBase {

        public List<Artist> ArtistsList { get; private set; }


        public AllArtistsViewModel() {
            //client.CurrentDevice.Id
            ArtistsList = client.DeviceGetArtists(1);


        }
    }
}
