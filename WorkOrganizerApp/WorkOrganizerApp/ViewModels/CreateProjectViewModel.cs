using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WorkOrganizerApp.Helpers;
using WorkOrganizerApp.Models;
using WorkOrganizerApp.Services;
using Xamarin.Forms;

namespace WorkOrganizerApp.ViewModels
{
    public class CreateProjectViewModel
    {
        ProjectApiService _projectApiService = new ProjectApiService();
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
       

        public ICommand CreateCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var project = new Project
                    {
                        Name = Name,
                        StartDate = StartDate,
                        EndDate = EndDate,
                        Description = Description
                    };
                    await _projectApiService.PostProjectAsync(project, PreferenceSettings.Token);
                });
            }
        }
    }
}
