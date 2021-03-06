﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicPickerApp.Toolkit {
    [ContentProperty("Source")]
    /// <summary>
    /// MarkExtension to easily add an Image from a local Source on a XAML Page
    /// </summary>
    public class ImageResourceExtension : IMarkupExtension {
        public string Source {
            get;
            set;
        }
        public object ProvideValue(IServiceProvider serviceProvider) {
            if (Source == null)
                return null;
            return ImageSource.FromResource(Source);
        }
    }
}
