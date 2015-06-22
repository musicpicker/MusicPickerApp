using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPickerApp.Api.Util
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Mbld { get; set; }
        public int ArtistId { get; set; }
        public string Artwork { get; set; }
    }
}
