using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkOrganizerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {

        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
        //    async void OnSignUpButtonClicked(object sender, EventArgs e)
        //    {
        //        var user = new User()
        //        {
        //            Firstname = firstnameEntry.Text,
        //            Lastname = lastnameEntry.Text,
        //            Password = passwordEntry.Text,
        //            Email = emailEntry.Text
        //        };

        //        // Sign up logic

        //        var signUpSucceeded = AreDetailsValid(user);
        //        if (signUpSucceeded)
        //        {
        //            var rootPage = Navigation.NavigationStack.FirstOrDefault();
        //            if (rootPage != null)
        //            {
        //                App.IsUserLoggedIn = true;
        //                Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
        //                await Navigation.PopToRootAsync();
        //            }
        //        }
        //        else
        //        {
        //            messageLabel.Text = "Sign up failed";
        //        }
        //    }

        //    bool AreDetailsValid(User user)
        //    {
        //        return (!string.IsNullOrWhiteSpace(user.Username) && !string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(user.Email) && user.Email.Contains("@"));
        //    }
        //}
    }
}