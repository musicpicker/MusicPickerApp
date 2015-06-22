using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MusicPickerApp.Api.Util;
using Microsoft.AspNet.SignalR.Client;

namespace MusicPickerApp.Api {
    /// <summary>
    /// Singleton class which regroups every call to the server the application need to do (HttpRequests and WebSockets)
    ///</summary>
    public sealed class ApiClient {
        private static readonly string SERVER_URL = "http://localhost:50559";
        private static readonly ApiClient instance = new ApiClient();
        private static readonly Uri endpoint = new Uri(SERVER_URL);
        private string bearer;
        private bool authenticated;
        public Device CurrentDevice { get; set; }
        public Artist CurrentArtist { get; set; }
        public Album CurrentAlbum { get; set; }
        public Track CurrentTrack { get; set; }

        private HubConnection hubConnection;
        private IHubProxy hubProxy;
        public static ApiClient Instance {
            get {
                return instance;
            }
        }

        private ApiClient() {
        }

        public bool SignUp(string username, string password) {
            Uri uri = new Uri(endpoint, "/api/Account/Register");
            HttpContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Username", username),
                new KeyValuePair<string, string>("Password", password),
                new KeyValuePair<string, string>("ConfirmPassword", password), 
            });

            HttpResponseMessage result = (new HttpClient()).PostAsync(uri, content).Result;

            if (result.IsSuccessStatusCode) {
                return true;
            }

            return false;
        }

        public string RetrieveBearer() {
            return this.bearer;
        }

        public void ProvideBearer(string bearer) {
            this.bearer = bearer;
        }

        public bool LogIn(string username, string password) {
            Uri uri = new Uri(endpoint, "/oauth/token");
            HttpContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            });

            HttpResponseMessage result = (new HttpClient()).PostAsync(uri, content).Result;
            if (!result.IsSuccessStatusCode) {
                return false;
            }

            Dictionary<string, string> data =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(result.Content.ReadAsStringAsync().Result);

            ProvideBearer(data["access_token"]);
            return true;
        }

        public int DeviceAdd(string name) {
            Uri uri = new Uri(endpoint, "/api/Devices");
            HttpContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", name),
            });

            HttpResponseMessage result = (new HttpClient() {
                DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", this.bearer) }
            }).PostAsync(uri, content).Result;
            if (!result.IsSuccessStatusCode) {
                return -1; // Exception @TODO
            }

            Dictionary<string, string> data =
               JsonConvert.DeserializeObject<Dictionary<string, string>>(result.Content.ReadAsStringAsync().Result);

            return Convert.ToInt32(data["Id"]);
        }

        public bool DeviceDelete(int deviceId) {
            Uri uri = new Uri(endpoint, string.Format("/api/Devices/{0}", deviceId));

            HttpResponseMessage result = (new HttpClient() {
                DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", this.bearer) }
            }).DeleteAsync(uri).Result;
            if (!result.IsSuccessStatusCode) {
                return false;
            }

            return true;
        }

        public async Task<bool> DeviceCollectionSubmit(int deviceId, string collection) {
            Uri uri = new Uri(endpoint, string.Format("/api/Devices/{0}/Submit", deviceId));

            HttpContent content = new StringContent(collection) {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };

            HttpResponseMessage result = await (new HttpClient() {
                DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", this.bearer) }
            }).PostAsync(uri, content);

            if (!result.IsSuccessStatusCode) {
                return false;
            }

            return true;
        }

        public List<Device> DevicesGet() {
            Uri uri = new Uri(endpoint, "/api/Devices");

            HttpResponseMessage result = (new HttpClient() {
                DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", this.bearer) }
            }).GetAsync(uri).Result;

            if (!result.IsSuccessStatusCode) {
                return null;  
            }

            return JsonConvert.DeserializeObject<List<Device>>(result.Content.ReadAsStringAsync().Result);
        }

        public int DeviceGetIdByName(string name) {
            Uri uri = new Uri(endpoint, string.Format("/api/Devices?name={0}", name));
            HttpResponseMessage result = (new HttpClient() {
                DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", this.bearer) }
            }).GetAsync(uri).Result;

            if (!result.IsSuccessStatusCode) {
                return -1;  
            }

            return JsonConvert.DeserializeObject<Device>(result.Content.ReadAsStringAsync().Result).Id;
        }

        public Album DevicesGetAlbum(int albumId) {
            Uri uri = new Uri(endpoint, string.Format("/api/Albums/{0}", albumId));

            HttpResponseMessage result = (new HttpClient() {
                DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", this.bearer) }
            }).GetAsync(uri).Result;

            if (!result.IsSuccessStatusCode) {
                return null;  
            }

            return JsonConvert.DeserializeObject<Album>(result.Content.ReadAsStringAsync().Result);
        }

        public List<Album> DeviceGetAlbums(int deviceId) {
            Uri uri = new Uri(endpoint, string.Format("/api/Albums?device={0}", deviceId));

            HttpResponseMessage result = (new HttpClient() {
                DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", this.bearer) }
            }).GetAsync(uri).Result;

            if (!result.IsSuccessStatusCode) {
                return null;  
            }

            return JsonConvert.DeserializeObject<List<Album>>(result.Content.ReadAsStringAsync().Result);
        }

        public List<Album> DeviceGetAlbumsFromArtist(int deviceId, int artistId) {
            Uri uri = new Uri(endpoint, string.Format("/api/Albums?device={0}&artist={1}", deviceId, artistId));

            HttpResponseMessage result = (new HttpClient() {
                DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", this.bearer) }
            }).GetAsync(uri).Result;

            if (!result.IsSuccessStatusCode) {
                return null;  
            }

            return JsonConvert.DeserializeObject<List<Album>>(result.Content.ReadAsStringAsync().Result);
        }

        public List<Track> DeviceGetTracks(int deviceId) {
            Uri uri = new Uri(endpoint, string.Format("/api/Tracks?device={0}", deviceId));
            HttpResponseMessage result = (new HttpClient() {
                DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", this.bearer) }
            }).GetAsync(uri).Result;

            if (!result.IsSuccessStatusCode) {
                return null;  
            }

            return JsonConvert.DeserializeObject<List<Track>>(result.Content.ReadAsStringAsync().Result);
        }

        public Track DevicesGetTrack(int trackId) {
            Uri uri = new Uri(endpoint, string.Format("/api/Tracks/{0}", trackId));
            HttpResponseMessage result = (new HttpClient() {
                DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", this.bearer) }
            }).GetAsync(uri).Result;

            if (!result.IsSuccessStatusCode) {
                return null;  
            }

            return JsonConvert.DeserializeObject<Track>(result.Content.ReadAsStringAsync().Result);
        }

        public List<Track> DeviceGetTracksFromAlbum(int deviceId, int albumId) {
            Uri uri = new Uri(endpoint, string.Format("/api/Tracks?device={0}&album={1}", deviceId, albumId));
            HttpResponseMessage result = (new HttpClient() {
                DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", this.bearer) }
            }).GetAsync(uri).Result;

            if (!result.IsSuccessStatusCode) {
                return null;  
            }

            return JsonConvert.DeserializeObject<List<Track>>(result.Content.ReadAsStringAsync().Result);
        }

        public Artist DevicesGetArtist(int artistId) {
            Uri uri = new Uri(endpoint, string.Format("/api/Artists/{0}", artistId));
            HttpResponseMessage result = (new HttpClient() {
                DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", this.bearer) }
            }).GetAsync(uri).Result;

            if (!result.IsSuccessStatusCode) {
                return null;  
            }

            return JsonConvert.DeserializeObject<Artist>(result.Content.ReadAsStringAsync().Result);
        }

        public List<Artist> DeviceGetArtists(int deviceId) {
            Uri uri = new Uri(endpoint, string.Format("/api/Artists?device={0}", deviceId));
            HttpResponseMessage result = (new HttpClient() {
                DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", this.bearer) }
            }).GetAsync(uri).Result;

            if (!result.IsSuccessStatusCode) {
                return null;  
            }

            return JsonConvert.DeserializeObject<List<Artist>>(result.Content.ReadAsStringAsync().Result);
        }
        public async void connectToHub() {

            hubConnection = new HubConnection("http://musicpicker.cloudapp.net");
            hubProxy = hubConnection.CreateHubProxy("MusicHub");
            hubConnection.Headers.Add("Authorization", "Bearer " + bearer);
            await hubConnection.Start();
            await hubProxy.Invoke("RegisterDevice", CurrentDevice.Id);
            
        }
        public async void playTrack() {
            object[] args = { CurrentDevice.Id, CurrentTrack.Id};
            //await hubProxy.Invoke('Queue', args);
            await hubProxy.Invoke("Play", CurrentDevice.Id);
        }
    }
}
