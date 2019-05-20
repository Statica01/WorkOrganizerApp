using System.Windows.Input;
using WorkOrganizerApp.Helpers;
using WorkOrganizerApp.Models;
using WorkOrganizerApp.Services;
using Xamarin.Forms;

namespace WorkOrganizerApp.ViewModels
{
    public class EditProjectViewModel
    {
        ProjectApiService _projectApiService = new ProjectApiService();

        public Project Project { get; set; }

        public ICommand EditCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _projectApiService.EditProjectAsync(Project, PreferenceSettings.Token);
                });
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _projectApiService.DeleteProjectAsync(Project.Id, PreferenceSettings.Token);
                });
            }
        }
    }
}
