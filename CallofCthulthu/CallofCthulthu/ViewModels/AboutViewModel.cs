using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace CallofCthulthu.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://en.wikipedia.org/wiki/Call_of_Cthulhu_%28role-playing_game%29")));
        }

        public ICommand OpenWebCommand { get; }
    }
}