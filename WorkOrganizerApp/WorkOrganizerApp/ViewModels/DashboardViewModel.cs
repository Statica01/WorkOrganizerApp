using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WorkOrganizerApp.Helpers;
using WorkOrganizerApp.Models;
using WorkOrganizerApp.Services;
using Xamarin.Forms;

namespace WorkOrganizerApp.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        private readonly LoginApiService _loginApiService = new LoginApiService();
        private readonly ProjectApiService _projectApiService = new ProjectApiService();
        private List<Project> _projects;

        //public string AccessToken { get; set; }
        public List<Project> Projects
        {
            get => _projects;
            set
            {
                _projects = value;
                OnPropertyChanged();
            }
        }
        public ICommand GetProjectsCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var Token = PreferenceSettings.Token;
                     Projects = await _projectApiService.GetProjectsAsync(Token);
                });
            }
        }

        public ICommand LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    PreferenceSettings.Token = string.Empty;
                    Debug.WriteLine(PreferenceSettings.Username);
                    PreferenceSettings.Username = string.Empty;
                    Debug.WriteLine(PreferenceSettings.Password);
                    PreferenceSettings.Password = string.Empty;

                    // navigate to LoginPage
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    //    public MainPageCS()
    //    {
    //        var toolbarItem = new ToolbarItem
    //        {
    //            Text = "Logout"
    //        };
    //        toolbarItem.Clicked += OnLogoutButtonClicked;
    //        ToolbarItems.Add(toolbarItem);

    //        Title = "Dashboard";
    //        Content = new StackLayout
    //        {
    //            Children = {
    //                new Label {
    //                    Text = "Dashboard",
    //                    HorizontalOptions = LayoutOptions.Center,
    //                    VerticalOptions = LayoutOptions.CenterAndExpand
    //                }
    //            }
    //        };
    //    }

    //    async void OnLogoutButtonClicked(object sender, EventArgs e)
    //    {
    //        App.IsUserLoggedIn = false;
    //        Navigation.InsertPageBefore(new LoginViewModel(), this);
    //        await Navigation.PopAsync();
    //    }
}

