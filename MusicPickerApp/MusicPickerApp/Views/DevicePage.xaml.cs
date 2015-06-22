using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPickerApp.ViewModels;
using MusicPickerApp.Views.TabbedViews;
using Xamarin.Forms;

namespace MusicPickerApp.Views {
    public partial class DevicePage : TabbedPage {
        public DevicePage() {
            InitializeComponent();
            this.BindingContext = viewModel;
            viewModel.AddSubViewModel(((ArtistsPage)Children[0]).getViewModel(),
            ((AlbumsPage)Children[1]).getViewModel(),
            ((TracksPage)Children[2]).getViewModel());


        }
    }
}
