using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPickerApp.Api.Util
{
    public class Device
    {
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime AccessDate { get; set; }
        public string Name { get; set; }
    }
}
