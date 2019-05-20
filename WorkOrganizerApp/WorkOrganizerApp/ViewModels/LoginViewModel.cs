using System.Windows.Input;
using WorkOrganizerApp.Helpers;
using WorkOrganizerApp.Services;
using Xamarin.Forms;

namespace WorkOrganizerApp.ViewModels
{
    public class LoginViewModel
    {
        private readonly LoginApiService _loginApiService = new LoginApiService();

        public string Token { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var token = await _loginApiService.LoginAsync(Username, Password);
                    PreferenceSettings.Token = token;
                });
            }
        }

        public LoginViewModel()
        {
            Token = PreferenceSettings.Token;
            Username = PreferenceSettings.Username;
            Password = PreferenceSettings.Password;
        }
    }
}
