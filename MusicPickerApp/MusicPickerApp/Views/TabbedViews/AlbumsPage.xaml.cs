﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPickerApp.ViewModels;
using Xamarin.Forms;

namespace MusicPickerApp.Views.TabbedViews {
    public partial class AlbumsPage : ContentPage {
        public AlbumsPage() {
            InitializeComponent();
            
        }
        public AllAlbumsViewModel getViewModel() {
            return viewModel;
        }
    }
}
