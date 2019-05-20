using System;
using System.ComponentModel;
using WorkOrganizerApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkOrganizerApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    // [DesignTimeVisible(true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        private async void NavigateToAddNewProject_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateProjectPage());
        }

        private async void ProjectListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var project = e.Item as Project;
            await Navigation.PushAsync(new EditProjectPage(project));
        }

        private async void NavigateToSearchProject_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchProjectPage());
        }

        private async void LogoutMenuItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}