using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MusicPickerApp.Toolkit {
    [ContentProperty("Items")]
    public class ObjectToListConverter<T> : IValueConverter {
        public IList<T> Items {
            set;
            get;
        }

        public ObjectToListConverter() {
            Items = new List<T>();
        }

        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture) {
            if (value == null || !(value is T) || Items == null)
                return null;
            Items.Add((T)value);
            return Items;
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture) {
            /*int index = (int)value;

            if (index < 0 || Items == null || index >= Items.Count)
                return null;

            return Items[index];*/
            if (value == null || !(value is T) || Items == null)
                return null;
            Items.Add((T)value);
            return Items;
        }
    }
}
