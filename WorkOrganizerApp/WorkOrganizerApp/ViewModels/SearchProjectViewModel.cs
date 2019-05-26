using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using WorkOrganizerApp.Helpers;
using WorkOrganizerApp.Models;
using WorkOrganizerApp.Services;
using Xamarin.Forms;

namespace WorkOrganizerApp.ViewModels
{
    public class SearchProjectViewModel : INotifyPropertyChanged
    {
        private readonly ProjectApiService _projectApiService = new ProjectApiService();
        private List<Project> _project;

        public List<Project> Projects
        {
            get => _project;
            set
            {
                _project = value;
                OnPropertyChanged();
            }
        }

        public string Keyword { get; set; }

        public ICommand SearchCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Projects = await _projectApiService.SearchProjectsAsync(Keyword, PreferenceSettings.Token);
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
