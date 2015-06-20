using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit { 
    public class DateTimeViewModel : INotifyPropertyChanged { 

        DateTime dateTime = DateTime.Now; 
        public event PropertyChangedEventHandler PropertyChanged; 
        public DateTimeViewModel() { 
            Device.StartTimer(TimeSpan.FromMilliseconds(15), OnTimerTick); 
        } 
        bool OnTimerTick() { 
            DateTime = DateTime.Now; 
            return true; 
        } 
        public DateTime DateTime { 
            private set { 
                if (dateTime != value) { 
                dateTime = value; 
                // Fire the event. 
                PropertyChangedEventHandler handler = PropertyChanged; 
                    if (handler != null) { 
                        handler(this, new PropertyChangedEventArgs("DateTime")); 
                    } 
                } 
            } 
            get { return dateTime; } 
        } 
    } 
}