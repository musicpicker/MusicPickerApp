using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MusicPickerApp.Api.Util;
using Xamarin.Forms;

namespace MusicPickerApp.ViewModels {
    class PollViewModel : ViewModelBase {
        public string DeviceName { get; private set; }
        public List<Track> PollList { get; private set; }
        public bool IsOngoingPoll { get; private set; }
        public PollViewModel() {


            DeviceName = client.CurrentDevice.Name;
            //PollList = client.DeviceGetVotes();


            VoteForTrackCommand = new Command<int>(execute: (int trackId) => {
                //client.deviceAddVote(trackId);
                App.Current.MainPage.DisplayAlert("Done !", "Your vote has been taken", "Ok");
            });


        }
        public ICommand VoteForTrackCommand {
            get;
            private set;
        }
    }
}
