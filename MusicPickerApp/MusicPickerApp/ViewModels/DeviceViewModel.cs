using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPickerApp.ViewModels {

    public class DeviceViewModel : ViewModelBase {
        public Api.Util.Device Device { get; set; }

        public DeviceViewModel() {

        }
    }
}
