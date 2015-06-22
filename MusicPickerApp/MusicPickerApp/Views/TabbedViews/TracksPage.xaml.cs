using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPickerApp.ViewModels;
using Xamarin.Forms;

namespace MusicPickerApp.Views.TabbedViews {
    public partial class TracksPage : ContentPage {
        public TracksPage() {
            InitializeComponent();
        }
        public AllTracksViewModel getViewModel() {
            return viewModel;
        }
    }
}
