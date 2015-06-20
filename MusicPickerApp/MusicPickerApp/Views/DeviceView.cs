using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPickerApp.Views {
    public class DeviceView {
        public string DeviceName {
            get;
            set;
        }
        public bool IsOwner {
            get;
            set;
        }
        public DeviceView(string deviceName, bool isOwner){
            DeviceName = deviceName;
            IsOwner = isOwner;
        }
    }
}
