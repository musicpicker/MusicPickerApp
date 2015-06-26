using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MusicPickerApp.Api.Util;
using MusicPickerApp.Views;
using Xamarin.Forms;

namespace MusicPickerApp.ViewModels {
    /// <summary>
    /// ViewModel of the Poll Page Which display on going poll or not
    /// The view is only static, the vote system has not been implemented yet
    /// </summary>
    class PollViewModel : ViewModelBase {
        public string DeviceName { get; private set; }
        public List<Track> PollList { get; private set; }
        public bool IsOngoingPoll { get; private set; }
        public PollViewModel() {

            try {
                DeviceName = client.CurrentDevice.Name;
                //PollList = client.DeviceGetVotes();
            } catch (Exception ex) {
                App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                App.Navigation.PopAsync();
            }

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
