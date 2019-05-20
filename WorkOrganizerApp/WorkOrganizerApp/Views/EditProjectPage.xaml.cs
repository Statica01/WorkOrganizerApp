using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOrganizerApp.Models;
using WorkOrganizerApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkOrganizerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProjectPage : ContentPage
    {
        public EditProjectPage(Project project)
        {
            InitializeComponent();

            var editProjectViewModel = new EditProjectViewModel();
            //var editProjectViewModel = BindingContext as EditProjectViewModel;

            editProjectViewModel.Project = project;

            BindingContext = editProjectViewModel;
        }
    }
}