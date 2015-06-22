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
    public class AllAlbumsViewModel : ViewModelBase {
       
        public List<Album> AlbumsList { get; private set; }


        public AllAlbumsViewModel() {
            //client.CurrentDevice.Id
            AlbumsList = client.DeviceGetAlbums(1);


        }
    }
}
