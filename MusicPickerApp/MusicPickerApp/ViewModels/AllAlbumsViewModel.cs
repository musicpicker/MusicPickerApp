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
    /// ViewModel use to display all the albums located on the Device
    /// </summary>
    public class AllAlbumsViewModel : ViewModelBase {

        public List<Album> AlbumsList { get; private set; }


        public AllAlbumsViewModel() {
            try { AlbumsList = client.DeviceGetAlbums(client.CurrentDevice.Id); } catch (Exception ex) {
                App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                App.Navigation.PopAsync();
            }


        }
    }
}
