using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MusicPickerApp.Views {
    public partial class AlbumTracksPage : ContentPage {
        public AlbumTracksPage() {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}
