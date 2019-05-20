using System.Windows.Input;
using WorkOrganizerApp.Helpers;
using WorkOrganizerApp.Services;
using Xamarin.Forms;

namespace WorkOrganizerApp.ViewModels
{
    public class SignUpViewModel
    {

        private readonly LoginApiService _loginApiService = new LoginApiService();

        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }

        public ICommand OnSignUpButtonClicked //SignUpCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isRegistered = await _loginApiService.SignUpUserAsync
                        (Username, Firstname, Lastname, SocialSecurityNumber, Email, Password);

                    PreferenceSettings.Username = Username;
                    PreferenceSettings.Password = Password;

                    if (isRegistered)
                    {
                        Message = "Success";
                    }
                    else
                    {
                        Message = "Please try again";
                    }
                });
                //Entry firstnameEntry, lastnameEntry, passwordEntry, emailEntry;
                //Label messageLabel;

                //public SignUpPageCS()
                //{
                //    messageLabel = new Label();
                //    firstnameEntry = new Entry
                //    {
                //        Placeholder = "Firstname"
                //    };
                //    lastnameEntry = new Entry
                //    {
                //        Placeholder = "Lastname"
                //    };
                //    passwordEntry = new Entry
                //    {
                //        IsPassword = true
                //    };
                //    emailEntry = new Entry();
                //    var signUpButton = new Button
                //    {
                //        Text = "Sign Up"
                //    };
                //    signUpButton.Clicked += OnSignUpButtonClicked;

                //    Title = "Sign Up";
                //    Content = new StackLayout
                //    {
                //        VerticalOptions = LayoutOptions.StartAndExpand,
                //        Children = {
                //            new Label { Text = "Firstname" },
                //            firstnameEntry,
                //            new Label { Text = "Lastname" },
                //            lastnameEntry,
                //            new Label { Text = "Password" },
                //            passwordEntry,
                //            new Label { Text = "Email address" },
                //            emailEntry,
                //            signUpButton,
                //            messageLabel
                //        }
                //    };
                //}

                //async void OnSignUpButtonClicked(object sender, EventArgs e)
                //{
                //    var user = new User()
                //    {
                //        Firstname = firstnameEntry.Text,
                //        Lastname = lastnameEntry.Text,
                //        Password = passwordEntry.Text,
                //        Email = emailEntry.Text
                //    };

                //    // Sign up logic

                //    var signUpSucceeded = AreDetailsValid(user);
                //    if (signUpSucceeded)
                //    {
                //        var rootPage = Navigation.NavigationStack.FirstOrDefault();
                //        if (rootPage != null)
                //        {
                //            App.IsUserLoggedIn = true;
                //            Navigation.InsertPageBefore(new MainPageCS(), Navigation.NavigationStack.First());
                //            await Navigation.PopToRootAsync();
                //        }
                //    }
                //    else
                //    {
                //        messageLabel.Text = "Sign up failed";
                //    }
                //}

                //bool AreDetailsValid(User user)
                //{
                //    return (!string.IsNullOrWhiteSpace(user.Username) && !string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(user.Email) && user.Email.Contains("@"));
                //}
            }
        }
    }
}
