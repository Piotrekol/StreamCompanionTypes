using System;
using System.ComponentModel;

namespace StreamCompanionTypes.Interfaces.Services
{
    public interface IMainWindowModel : INotifyPropertyChanged
    {
        string BeatmapsLoaded { get; set; }
        string NowPlaying { get; set; }
        string UpdateText { get; set; }
        event EventHandler OnUpdateTextClicked;
        void UpdateTextClicked(object sender, EventArgs e);
    }
}