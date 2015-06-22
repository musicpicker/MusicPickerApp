using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MusicPickerApp.Views {
    public partial class PollPage : ContentPage {
        public PollPage() {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}
