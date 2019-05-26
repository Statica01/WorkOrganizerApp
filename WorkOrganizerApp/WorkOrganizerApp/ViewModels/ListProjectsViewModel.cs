using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WorkOrganizerApp.Helpers;
using WorkOrganizerApp.Models;
using WorkOrganizerApp.Services;
using Xamarin.Forms;

namespace WorkOrganizerApp.ViewModels

// TODO List all jobs included in a project. <=========================================== TODO !
{
    public class ListProjectsViewModel : INotifyPropertyChanged
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
        public ICommand GetProjectCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accessToken = PreferenceSettings.Token;
                    Projects = await _projectApiService.GetProjectsAsync(accessToken);
                });
            }
        }

   

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
