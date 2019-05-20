using System;
using System.Collections.Generic;
using System.Text;
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
        public string Email { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var token = await _loginApiService.LoginAsync(Email, Password);
                    PreferenceSettings.Token = token;
                });
            }
        }

        public LoginViewModel()
        {
            Token = PreferenceSettings.Token;
            Email = PreferenceSettings.Email;
            Password = PreferenceSettings.Password;
        }
    }
}
