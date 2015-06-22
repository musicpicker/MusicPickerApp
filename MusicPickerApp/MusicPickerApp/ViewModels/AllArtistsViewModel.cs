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
    /// ViewModel use to display all the artists located on the Device
    /// </summary>
    public class AllArtistsViewModel : ViewModelBase {

        public List<Artist> ArtistsList { get; private set; }

        public AllArtistsViewModel() {
            ArtistsList = client.DeviceGetArtists(client.CurrentDevice.Id);


        }
    }
}
