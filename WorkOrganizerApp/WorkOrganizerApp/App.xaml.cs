using System;
using WorkOrganizerApp.Helpers;
using WorkOrganizerApp.ViewModels;
using Xamarin.Forms;
using WorkOrganizerApp.Views;

namespace WorkOrganizerApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new NavigationPage(new SignUpPage());
            SetMainPage();
        }
        private void SetMainPage()
        {
            if (!string.IsNullOrEmpty(PreferenceSettings.Token))
            {
                if (PreferenceSettings.AccessTokenExpirationDate < DateTime.UtcNow.AddHours(1))
                {
                    var loginViewModel = new LoginViewModel();
                    loginViewModel.LoginCommand.Execute(null);
                }
                MainPage = new NavigationPage(new DashboardPage());
            }
            else if (!string.IsNullOrEmpty(PreferenceSettings.Username)
                     && !string.IsNullOrEmpty(PreferenceSettings.Password))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new SignUpPage());
            }
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
