using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Essentials;

namespace WorkOrganizerApp.Helpers
{
    public class PreferenceSettings : HttpClient
    {
        public static string Token
        {
            get => Xamarin.Essentials.Preferences.Get(nameof(Token), "");
            set => Xamarin.Essentials.Preferences.Set(nameof(Token), value);
        }

        public static string RefreshToken
        {
            get => Xamarin.Essentials.Preferences.Get(nameof(RefreshToken), "");
            set => Preferences.Set(nameof(RefreshToken), value);
        }

        public PreferenceSettings()
        {
            BaseAddress = new Uri("http://localhost:44390");

            if (!string.IsNullOrEmpty(Token))
            {
                DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", PreferenceSettings.Token);
            }
        }
        public static DateTime AccessTokenExpirationDate
        {
            get => Preferences.Get(nameof(AccessTokenExpirationDate), DateTime.Now);
            set => Preferences.Set(nameof(AccessTokenExpirationDate), value);

        }

        public static string Email
        {
            get => Xamarin.Essentials.Preferences.Get(nameof(Email), ""); //... ,string.Empty);
            set => Xamarin.Essentials.Preferences.Set(nameof(Email), value);
        }

        public static string Password
        {
            get => Xamarin.Essentials.Preferences.Get(nameof(Password), "");
            set => Xamarin.Essentials.Preferences.Set(nameof(Password), value);
        }
    }
}
