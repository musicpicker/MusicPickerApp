using LiteDB;
using Newtonsoft.Json;

namespace MusicPickerApp.Api.Util
{
    public class Track
    {
        [JsonConverter(typeof(ToStringJsonConverter))]
        public ObjectId Id { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public uint Year { get; set; }
        public uint Number { get; set; }
        public uint Count { get; set; }
        public int Duration { get; set; }
        [BsonIndex]
        public string Path { get; set; }
    }
}