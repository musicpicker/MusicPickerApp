using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class AltLabel : Label {
        public static readonly BindableProperty PointSizeProperty; 
            public double PointSize { 
                set { SetValue(PointSizeProperty, value); } 
                get { return (double)GetValue(PointSizeProperty); } }
    }
}