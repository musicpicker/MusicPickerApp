﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPickerApp.ViewModels;
using Xamarin.Forms;

namespace MusicPickerApp.Views {
    public partial class DevicesListPage : ContentPage {

        public DevicesListPage() {

            InitializeComponent();
            this.BindingContext = new DevicesListViewModel();
            MenuItem m = new MenuItem();
        }
        
    }
}
