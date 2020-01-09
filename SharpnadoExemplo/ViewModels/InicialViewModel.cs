using System;
using Xamarin.Forms;

namespace SharpnadoExemplo.ViewModels
{
    public class InicialViewModel : BaseViewModel
    {
        public Command IniciarCommand { get; }

        public InicialViewModel()
        {
            IniciarCommand = new Command(ExecuteIniciarCommand);
        }

        private async void ExecuteIniciarCommand()
        {
            await Navigation.PushAsync<MainViewModel>(false);
        }
    }
}
