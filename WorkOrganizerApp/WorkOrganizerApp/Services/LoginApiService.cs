using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WorkOrganizerApp.Helpers;
using WorkOrganizerApp.Models;
using Xamarin.Forms;

namespace WorkOrganizerApp.Services
{
    internal class LoginApiService
    {
        public async Task<string> LoginAsync(string username, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
               // new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(
                HttpMethod.Post, Constants.BaseApiAddress + "/token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(content);

            var accessTokenExpiration = jwtDynamic.Value<DateTime>(".expires");
            var accessToken = jwtDynamic.Value<string>("access_token");

            PreferenceSettings.AccessTokenExpirationDate = accessTokenExpiration;

            Debug.WriteLine(accessTokenExpiration);

            Debug.WriteLine(content);

            return accessToken;
        }

        public async Task<bool> SignUpUserAsync(string username, string firstname, string lastname, string socialSecurityNumber,
            string email, string password)
        {
            var client = new HttpClient();

            var model = new User
            {
                Username = username,
                Firstname = firstname,
                Lastname = lastname,
                SocialSecurityNumber = socialSecurityNumber,
                Email = email,
                Password = password,

            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(
                Constants.BaseApiAddress + "/users", httpContent);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
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
    }
}
